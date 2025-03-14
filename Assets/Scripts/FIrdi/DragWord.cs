using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragWord : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public RectTransform[] availableSlots; // Assign multiple slots in Inspector
    public int correctSpot; // The correct slot index for this word
    public Manager manager;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalAnchoredPosition;
    private Transform originalParent;
    private Canvas canvas;

    private RectTransform currentSlot = null; // Stores the slot the word is in
    private bool wasCorrect = false; // Track if the word was in the correct slot
    private static Dictionary<RectTransform, bool> slotOccupied = new Dictionary<RectTransform, bool>();

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>() ?? gameObject.AddComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        originalAnchoredPosition = rectTransform.anchoredPosition;
        originalParent = transform.parent;

        // Initialize slot availability
        foreach (var slot in availableSlots)
        {
            if (!slotOccupied.ContainsKey(slot))
                slotOccupied[slot] = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.7f;
        transform.SetParent(canvas.transform, true);

        // If moving away from the correct slot, deduct score
        if (currentSlot != null)
        {
            if (wasCorrect) // Only deduct if it was in the correct slot
            {
                manager.score(-1);
            }

            slotOccupied[currentSlot] = false; // Free the slot
            currentSlot = null;
            wasCorrect = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        RectTransform targetSlot = GetAvailableSlot();

        if (targetSlot != null)
        {
            SnapToSlot(targetSlot);
        }
        else
        {
            ResetPosition();
        }
    }

    private RectTransform GetAvailableSlot()
    {
        foreach (var slot in availableSlots)
        {
            if (!slotOccupied[slot] && IsOverSlot(slot))
            {
                return slot;
            }
        }
        return null; // No available slot
    }

    private bool IsOverSlot(RectTransform slot)
    {
        Vector2 wordLocalPosition = slot.InverseTransformPoint(rectTransform.position);
        return slot.rect.Contains(wordLocalPosition);
    }

    private void SnapToSlot(RectTransform slot)
    {
        transform.SetParent(slot.transform, false);
        rectTransform.anchoredPosition = Vector2.zero;
        slotOccupied[slot] = true; // Mark slot as occupied
        currentSlot = slot; // Store current slot

        // Check if this is the correct slot
        WordSlot slotComponent = slot.GetComponent<WordSlot>();
        if (slotComponent != null && slotComponent.slotID == correctSpot)
        {
            if (!wasCorrect) // Only increase if it wasn't already counted
            {
                manager.score(1);
            }
            wasCorrect = true;
        }
        else
        {
            wasCorrect = false;
        }
    }

    private void ResetPosition()
    {
        transform.SetParent(originalParent, false);
        rectTransform.anchoredPosition = originalAnchoredPosition;
    }
}
