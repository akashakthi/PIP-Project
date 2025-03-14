using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int maxScore;
    public int currentScore;
    public GameObject current;
    public GameObject next;

    private void Update()
    {
        if(currentScore == maxScore)
        {
            current.SetActive(false);
            next.SetActive(true);
        }
    }

    public void score(int score)
    {
        currentScore += score;
    }
}
