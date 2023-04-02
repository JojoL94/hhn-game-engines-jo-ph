using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManager : MonoBehaviour
{
    private int p1Score = 0;
    private int leben = 3;
    public TMP_Text textMesh, stopwatchText;
    public static ScriptManager instance;

    public float stopwatchTime, startTime, endTime;

    public int P1Score
    {
        set
        {
            p1Score = value;
            updateScoreDisplay();
            
        }
        get
        {
            return p1Score;
        }
    }
    
    public int Leben
    {
        set
        {
            leben = value;
            if (leben == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            updateScoreDisplay();
            
        }
        get
        {
            return leben;
        }
    }

    void updateScoreDisplay()
    {
        textMesh.text = "Points: " + p1Score + "\n Hearts: "  + leben;
    }

    private void Awake()
    {
        instance = this;
    }

    public void stopTime()
    {
        endTime = Time.time;
        stopwatchTime = endTime - startTime;
        stopwatchText.text = Mathf.FloorToInt(stopwatchTime / 60) + "m " + Mathf.Round(stopwatchTime - (60 * Mathf.FloorToInt(stopwatchTime / 60))) + "s ";

    }
    
}
