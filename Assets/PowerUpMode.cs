using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpMode : MonoBehaviour
{

    private bool glue = false;
    private bool grow = false;
    public GameObject ball;
    // Update is called once per frame

    public void PowerUpOn(int powerUpMode)
    {
        Debug.Log(powerUpMode);

        if (powerUpMode == 1)
        {
            ball.GetComponent<Ball>().Glued();
            glue = true;
            Debug.Log("PowerUp Mode 1 ist an");
        } else if (powerUpMode == 2)
        {
            grow = true;
        }
    }
}
