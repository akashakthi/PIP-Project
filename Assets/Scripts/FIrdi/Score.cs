using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] bool Level;
    [SerializeField] int scoreValue;
    [SerializeField] int totalScore;
    [SerializeField] GameObject currentQuest;
    [SerializeField] GameObject currentQuest1;
    [SerializeField] GameObject NextQuest;
    [SerializeField] GameObject NextQuest1;
    [SerializeField] string Levelname;

    public void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(scoreValue <= 0)
        {
            scoreValue = 0;
        }
        if(scoreValue == totalScore)
        {
            if (!Level)
            {
                StartCoroutine(ChangeQuest());
            }else if (Level)
            {
                StartCoroutine(ChangeLevel());
            }
        }
    }

    public void PlusScore(int score)
    {
        scoreValue += score;
    }
    public void MinusScore(int score)
    {
        scoreValue -= score;
    }
    IEnumerator ChangeQuest()
    {
        yield return new WaitForSeconds(1f);
        currentQuest.SetActive(false);
        currentQuest1.SetActive(false);
        NextQuest.SetActive(true);
        NextQuest1.SetActive(true);
    }
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Levelname);
    }
}
