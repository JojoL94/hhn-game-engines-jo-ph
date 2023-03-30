using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStone : MonoBehaviour
{
    // Update is called once per frame
    public int powerUpMode;
    private float timeRemaining = 20f;

    bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,-1f) * Time.deltaTime;
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
               // Debug.Log("Time has run out!");
                timeRemaining = 0;
                Destroy(gameObject);
                timerIsRunning = false;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            other.GetComponent<PowerUpState>().PowerUpOn(powerUpMode);
            Destroy(gameObject);
        }
        
    }
}
