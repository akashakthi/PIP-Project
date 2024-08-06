using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public void levelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void levelTwo() 
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void levelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }
    public void levelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }
    public void levelFive()
    {
        SceneManager.LoadScene("LevelFive");
    }
    public void levelSix()
    {
        SceneManager.LoadScene("LevelSix");
    }
    public void levelSeven()
    {
        SceneManager.LoadScene("LevelSeven");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void splashScreen()
    {
        SceneManager.LoadScene("splashScreen");
    }
    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
