using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private Dragable lastDrag;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragActive && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if(Input.touchCount > 0)
        {
            if (lastDrag.sameTag = false)
            {
                screenPosition = Input.GetTouch(0).position;
            }
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Dragable draggable = hit.transform.gameObject.GetComponent<Dragable>();
                if(draggable != null)
                {
                    lastDrag = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        isDragActive = true;
    }

    void Drag()
    {
        lastDrag.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void Drop()
    {
        isDragActive = false;
        Vector2 dropPos = lastDrag.isTag ? lastDrag.gameObject.transform.position = lastDrag.answerPos : lastDrag.gameObject.transform.position = lastDrag.startPosition;
    }
}
