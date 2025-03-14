using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject[] Line;
    public string SceneName;
    public bool part2;
    public GameObject congrats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Line[0].activeSelf == true &&
            Line[1].activeSelf == true &&
            Line[2].activeSelf == true &&
            Line[3].activeSelf == true)
        {
            if (!part2)
            {
                SceneManager.LoadScene(SceneName);
            }
            else
            {
                congrats.SetActive(true);
            }
        }
    }
}
