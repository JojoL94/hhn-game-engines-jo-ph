using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    private float tmpMaxX;
    private float tmpMaxZ;
    public float maxX;
    public float maxZ;
    private Vector3 velocity;
    public Transform playArea;
    private bool gluedOnPaddle = false;
    private bool glued = false;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, maxZ);

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += velocity * Time.deltaTime;
        float maxZPosition = playArea.localScale.z * 0.5f * 10;
        if (transform.position.z > maxZPosition)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            velocity = new Vector3(0, 0, -maxZ);
            GameManager.instance.P1Score += 1;
        }
        else if(transform.position.z < -maxZPosition)
        {
            transform.position = new Vector3(0, 0.5f, 0);
            velocity = new Vector3(0, 0, maxZ);
            GameManager.instance.P2Score += 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gluedOnPaddle)
            {
                maxX = tmpMaxX;
                maxZ = tmpMaxZ;
                glued = false;
                gluedOnPaddle = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            if (glued)
            {
                Debug.Log("Glued Boolean funktioniert");
                tmpMaxX = maxX;
                tmpMaxZ = maxZ;
                maxX = 0;
                maxZ = 0;
                gluedOnPaddle = true;
            }
            else
            {
                float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
                float actualDist = transform.position.x - other.transform.position.x;
                float distNorm = actualDist / maxDist;
                velocity.x = distNorm * maxX;
                velocity.z *= -1;
            }

        }
        else if (other.CompareTag(("Wall")))
        {
            velocity.x *= -1;
        }
        //velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        GetComponent<AudioSource>().Play();
    }

    public void Glued()
    {
        glued = true;
    }
}