using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int p1Score = 0;
    private int leben = 3;
    public TMP_Text textMesh;
    public static GameManager instance;

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
        textMesh.text = "Punkte: " + p1Score + "\n Leben: "  + leben;
    }
    private void Awake()
    {
        instance = this;
    }
    
}
