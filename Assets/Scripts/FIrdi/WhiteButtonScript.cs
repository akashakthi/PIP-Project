using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteButtonScript : MonoBehaviour
{
    public bool thisButton;
    public ButtonandLine[] buttonLine;

    private Image buttonImage;
    public Color pressedColor;
    public Color unpressedColor;

    public LineManager lineManager;
    public int No;

    private void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (thisButton == true && lineManager.lineChecker[No] == false)
        {
            buttonImage.color = pressedColor;
            if (buttonLine[0].BlackButtonUI.thisButton == true && buttonLine[0].BlackButtonUI.isConnected == false)
            {
                buttonLine[0].BlackButtonUI.isConnected = true;
                buttonLine[0].line.SetActive(true);
                buttonLine[1].line.SetActive(false);
                buttonLine[2].line.SetActive(false);
                buttonLine[3].line.SetActive(false);
            }
            else if (buttonLine[1].BlackButtonUI.thisButton == true && buttonLine[1].BlackButtonUI.isConnected == false)
            {
                buttonLine[1].BlackButtonUI.isConnected = true;
                buttonLine[0].line.SetActive(false);
                buttonLine[1].line.SetActive(true);
                buttonLine[2].line.SetActive(false);
                buttonLine[3].line.SetActive(false);
            }
            else if (buttonLine[2].BlackButtonUI.thisButton == true && buttonLine[2].BlackButtonUI.isConnected == false)
            {
                buttonLine[2].BlackButtonUI.isConnected = true;
                buttonLine[0].line.SetActive(false);
                buttonLine[1].line.SetActive(false);
                buttonLine[2].line.SetActive(true);
                buttonLine[3].line.SetActive(false);
            }
            else if (buttonLine[3].BlackButtonUI.thisButton == true && buttonLine[3].BlackButtonUI.isConnected == false)
            {
                buttonLine[3].BlackButtonUI.isConnected = true;
                buttonLine[0].line.SetActive(false);
                buttonLine[1].line.SetActive(false);
                buttonLine[2].line.SetActive(false);
                buttonLine[3].line.SetActive(true);
            }
        }
        else if(thisButton == false)
        {
            buttonImage.color = unpressedColor;
        }
    }
    public void onWhiteButtonPressed()
    {
        if (thisButton == false)
        {
            thisButton = true;
        }
        else
        {
            thisButton = false;
            lineManager.lineChecker[No] = false;
            if(buttonLine[0].line.activeSelf == true && buttonLine[0].BlackButtonUI.thisButton == true)
            {
                buttonLine[0].line.SetActive(false);
                buttonLine[0].BlackButtonUI.thisButton = false;
            }
            if(buttonLine[1].line.activeSelf == true && buttonLine[1].BlackButtonUI.thisButton == true)
            {
                buttonLine[1].line.SetActive(false);
                buttonLine[1].BlackButtonUI.thisButton = false;
            }
            if(buttonLine[2].line.activeSelf == true && buttonLine[2].BlackButtonUI.thisButton == true)
            {
                buttonLine[2].line.SetActive(false);
                buttonLine[2].BlackButtonUI.thisButton = false;
            }
            if(buttonLine[3].line.activeSelf == true && buttonLine[3].BlackButtonUI.thisButton == true)
            {
                buttonLine[3].line.SetActive(false);
                buttonLine[3].BlackButtonUI.thisButton = false;
            }
            Debug.Log("Button is Pressed");
        }
    }
}

[System.Serializable]
public class ButtonandLine
{
    public BlackButtonScript BlackButtonUI;
    public GameObject line;
}
