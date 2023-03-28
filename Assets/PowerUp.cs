using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Transform playArea;
    // Update is called once per frame
    public int powerUpMode;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,0,-1f) * Time.deltaTime;
        float maxZPosition = playArea.localScale.z * 0.5f * 10;

        if(transform.position.z < -maxZPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paddle"))
        {
            Debug.Log("Collider funktioniert");
            other.GetComponent<PowerUpMode>().PowerUpOn(powerUpMode);
        }
        
    }
}
