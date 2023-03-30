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
    public TMP_Text textMesh;
    public static ScriptManager instance;

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
    
}
