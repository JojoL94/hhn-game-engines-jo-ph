using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    public float maxX;
    public float maxZ;
    private Vector3 velocity;
    public Transform playArea;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, maxZ);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Score: " + GameManager.instance.P1Score + " - " + GameManager.instance.P2Score);
        }
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
            float actualDist = transform.position.x - other.transform.position.x;
            float distNorm = actualDist / maxDist;
            velocity.x = distNorm * maxX;
            velocity.z *= -1;
        }
        else if (other.CompareTag(("Wall")))
        {
            velocity.x *= -1;
        }
        //velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        GetComponent<AudioSource>().Play();
        

    }
}