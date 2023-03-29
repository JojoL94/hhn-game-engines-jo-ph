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
    public float timeRemaining = 5f;

    bool timerIsRunning = false;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 1, transform.localScale.y, transform.localScale.z);
                Debug.Log("Time has run out!");
                timeRemaining = 5f;
                timerIsRunning = false;
            }
        }
    }
    public void PowerUpOn(int powerUpMode)
    {
        Debug.Log(powerUpMode);

        if (powerUpMode == 1)
        {
            ball.GetComponent<Ball>().Glued();
            glue = true;
        } else if (powerUpMode == 2)
        {
            grow = true;
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
            timerIsRunning = true;

        }
    }
}
