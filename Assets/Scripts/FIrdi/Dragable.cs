using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public bool isTag;
    public bool sameTag;
    public Vector2 startPosition;
    public Vector2 answerPos;

    private void Start()
    {
        startPosition = gameObject.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("answer"))
        {
            isTag = true;
            answerPos = collision.gameObject.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("answer"))
        {
            isTag = true;
            answerPos = collision.gameObject.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("answer"))
        {
            isTag = false;
        }
    }
}
