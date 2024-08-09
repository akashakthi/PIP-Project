using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public bool isTag;
    public bool sameTag;
    public Vector2 startPosition;
    public Vector2 answerPos;
    public Transform rightAnswerLocation;
    public string tagName;
    public int score;

    private void Start()
    {
        startPosition = gameObject.transform.position;
    }
    private void Update()
    {
        if (this.score <= 0)
        {
            this.score = 0;
        }
        else if( this.score >= 1)
        {
            this.score = 1;
        }
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
        if (collision.gameObject.CompareTag(tagName))
        {
            Score.instance.PlusScore(1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("answer"))
        {
            isTag = false;
        }
        if (collision.gameObject.CompareTag(tagName))
        {
            Score.instance.MinusScore(1);
        }
    }
}
