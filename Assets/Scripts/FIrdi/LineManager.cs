using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public LineArray[] lineArrays;
    public bool[] lineChecker;

    // Update is called once per frame
    void Update()
    {
        if (lineArrays[0].Line[0].active == true || 
            lineArrays[0].Line[1].active == true || 
            lineArrays[0].Line[2].active == true ||
            lineArrays[0].Line[3].active == true)
        {
            lineChecker[0] = true;
        }
        else
        {
            lineChecker[0] = false;
        }

        if (lineArrays[1].Line[0].active == true ||
            lineArrays[1].Line[1].active == true ||
            lineArrays[1].Line[2].active == true ||
            lineArrays[1].Line[3].active == true)
        {
            lineChecker[1] = true;
        }
        else
        {
            lineChecker[1] = false;
        }

        if (lineArrays[2].Line[0].active == true ||
            lineArrays[2].Line[1].active == true ||
            lineArrays[2].Line[2].active == true ||
            lineArrays[2].Line[3].active == true)
        {
            lineChecker[2] = true;
        }
        else
        {
            lineChecker[2] = false;
        }

        if (lineArrays[3].Line[0].active == true ||
            lineArrays[3].Line[1].active == true ||
            lineArrays[3].Line[2].active == true ||
            lineArrays[3].Line[3].active == true)
        {
            lineChecker[3] = true;
        }
        else
        {
            lineChecker[3] = false;
        }

    }
}

[System.Serializable]
public class LineArray
{
    public GameObject[] Line;
}
