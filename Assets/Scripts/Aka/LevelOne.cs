using UnityEngine;


public class LevelOne : MonoBehaviour
{
    public GameObject QuestionsOne;
    public GameObject QuestionsTwo;
    public GameObject QuestionsThree;
    // Start is called before the first frame update
    void Awake()
    {
        QuestionsOne.SetActive(true); QuestionsTwo.SetActive(false); QuestionsThree.SetActive(false);
    }

    // Update is called once per frame

    
    public void nextQuestionsTwo()
    {
        QuestionsOne.SetActive(false); QuestionsTwo.SetActive(true); QuestionsThree.SetActive(false);
    }

    public void nextQuestionsThree()
    {
        QuestionsOne.SetActive(false); QuestionsTwo.SetActive(false); QuestionsThree.SetActive(true);
    }

}
