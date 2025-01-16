using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackButtonScript : MonoBehaviour
{
    public bool thisButton;
    public bool isConnected;

    private Image buttonImage;
    public Color pressedColor;
    public Color unpressedColor;

    public LineManager lineManager;
    public int No;

    public ButtonandLine[] buttonLine;

    private void Start()
    {
        buttonImage = gameObject.GetComponent<Image>();
    }
    private void Update()
    {
        if (thisButton == true)
        {
            buttonImage.color = pressedColor;
        }
        else if(thisButton == false)
        {
            isConnected = false;
            buttonImage.color = unpressedColor;
        }
    }
    public void OnBlackButtonPressed()
    {
        if (thisButton == false)
        {
            thisButton = true;
        }
        else
        {
            thisButton = false;
            lineManager.lineChecker[No] = false;

            if (buttonLine[0].whiteButtonUI.thisButton == true && buttonLine[0].line.activeSelf == true) 
            { 
                buttonLine[0].whiteButtonUI.thisButton = false;
                buttonLine[0].line.SetActive(false);
            }
            if(buttonLine[1].whiteButtonUI.thisButton == true && buttonLine[1].line.activeSelf == true) 
            { 
                buttonLine[1].whiteButtonUI.thisButton = false;
                buttonLine[1].line.SetActive(false);
            }
            if(buttonLine[2].whiteButtonUI.thisButton == true && buttonLine[2].line.activeSelf == true) 
            { 
                buttonLine[2].whiteButtonUI.thisButton = false;
                buttonLine[2].line.SetActive(false);
            }
            if(buttonLine[3].whiteButtonUI.thisButton == true && buttonLine[3].line.activeSelf == true) 
            { 
                buttonLine[3].whiteButtonUI.thisButton = false;
                buttonLine[3].line.SetActive(false);
            }
        }
    }

    [System.Serializable]
    public class ButtonandLine
    {
        public WhiteButtonScript whiteButtonUI;
        public GameObject line;
    }
}
