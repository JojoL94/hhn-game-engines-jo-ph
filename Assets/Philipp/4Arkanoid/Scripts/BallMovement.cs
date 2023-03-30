using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallMovement : MonoBehaviour
{
    public float maxX;
    public float maxZ;
    private Vector3 _velocity;
    public Transform playArea;
    private bool gluedOnPaddle = false;
    private bool glued = false;

    public Transform paddleTra;
    bool gameStarted;

    public GameObject pressSpace;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            transform.parent = paddleTra;
            pressSpace.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _velocity = new Vector3(0, 0, maxZ);
                gameStarted = true;
                transform.parent = null;
                pressSpace.SetActive(false);
            }
        }

        if (gluedOnPaddle)
        {
            transform.position = new Vector3(paddleTra.position.x, transform.position.y, transform.position.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                glued = false;
                gluedOnPaddle = false;
            }
        }
        else
        {
            transform.position += _velocity * Time.deltaTime;
            float maxZPosition = playArea.localScale.z * 0.5f * 10;
            if (transform.position.z > maxZPosition)
            {
                transform.position = new Vector3(0, 0.5f, 0);
                _velocity = new Vector3(0, 0, -maxZ);

            }
            else if(transform.position.z < -maxZPosition)
            {
                transform.position = new Vector3(0, 0.5f, 0);
                _velocity = new Vector3(0, 0, maxZ);
                ScriptManager.instance.Leben -= 1;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle") || other.CompareTag("Brick"))
        {
            if (glued && other.CompareTag("Paddle"))
            {
                float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
                float actualDist = transform.position.x - other.transform.position.x;
                float distNorm = actualDist / maxDist;
                _velocity.x = distNorm * maxX;
                _velocity.z *= -1;
                gluedOnPaddle = true;
            }
            else
            {
                float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
                float actualDist = transform.position.x - other.transform.position.x;
                float distNorm = actualDist / maxDist;
                _velocity.x = distNorm * maxX;
                _velocity.z *= -1;
            }

        }
        else if (other.CompareTag("Hori.Wall"))
        {
            
            float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
            float actualDist = transform.position.x - other.transform.position.x;
            float distNorm = actualDist / maxDist;
            _velocity.x = distNorm * maxX;
            _velocity.z *= -1;
            
        }
        else if (other.CompareTag(("Wall")))
        {
            _velocity.x *= -1;
        }
        GetComponent<AudioSource>().Play();
    }

    public void Glued()
    {
        glued = true;
    }
}