using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlDragAndDrop : MonoBehaviour
{
    public GameObject[] item;
    public GameObject[] itemDrop;
    public GameObject Questions;

    public int score;
    public int maxScore;

    public int jarak; // untuk menentukan jarak antar item dan item drop

    public Vector2[] itemPos; // menyimpan posisi pertama waktu game dimulai

    private bool isDragging = false;
    private int draggingItemIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        itemPos = new Vector2[item.Length];
        for (int i = 0; i < item.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleTouch();
        HandleMouse();
    }

    void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (RectTransformUtility.RectangleContainsScreenPoint(item[i].GetComponent<RectTransform>(), touch.position, Camera.main))
                        {
                            isDragging = true;
                            draggingItemIndex = i;
                            break;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging && draggingItemIndex >= 0)
                    {
                        Vector3 worldPoint;
                        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(item[draggingItemIndex].GetComponent<RectTransform>(), touch.position, Camera.main, out worldPoint))
                        {
                            item[draggingItemIndex].transform.position = new Vector3(worldPoint.x, worldPoint.y, item[draggingItemIndex].transform.position.z);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    if (isDragging && draggingItemIndex >= 0)
                    {
                        ItemEndDrag(draggingItemIndex);
                        isDragging = false;
                        draggingItemIndex = -1;
                    }
                    break;
            }
        }
    }

    void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            for (int i = 0; i < item.Length; i++)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(item[i].GetComponent<RectTransform>(), mousePos, Camera.main))
                {
                    isDragging = true;
                    draggingItemIndex = i;
                    break;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (isDragging && draggingItemIndex >= 0)
            {
                Vector3 worldPoint;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(item[draggingItemIndex].GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out worldPoint))
                {
                    item[draggingItemIndex].transform.position = new Vector3(worldPoint.x, worldPoint.y, item[draggingItemIndex].transform.position.z);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging && draggingItemIndex >= 0)
            {
                ItemEndDrag(draggingItemIndex);
                isDragging = false;
                draggingItemIndex = -1;
            }
        }
    }

    public void ItemEndDrag(int _number)
    {
        float distance = Vector3.Distance(item[_number].transform.localPosition, itemDrop[_number].transform.localPosition);

        if (distance < jarak)
        {
            item[_number].transform.localPosition = itemDrop[_number].transform.localPosition;
            score += 1;
            print("Score = " + score);
        }
        else
        {
            item[_number].transform.localPosition = itemPos[_number];
        }

        if (maxScore <= score)
        {
            Questions.SetActive(true);
        }
    }

}
