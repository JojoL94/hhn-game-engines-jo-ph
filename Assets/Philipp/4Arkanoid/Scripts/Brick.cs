using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1; // Die Anzahl der Treffer, die der Stein aushält, bevor er zerstört wird
    public Material materialHealth1;
    public Material materialHealth2;
    public Material materialHealth3;
    private void Start()
    {
        if (health == 1)
        {
            GetComponent<MeshRenderer> ().material = materialHealth1;
        }
        else if (health == 2)
        {
            GetComponent<MeshRenderer> ().material = materialHealth2;
        }
        else
        {
            GetComponent<MeshRenderer> ().material = materialHealth3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball")) // Überprüfen Sie, ob die Kollision mit dem Ball stattgefunden hat
        {

            health--; // Verringern Sie die Gesundheit des Steins um 1
            if (health == 1)
            {
                GetComponent<MeshRenderer> ().material = materialHealth1;
            }
            else if (health == 2)
            {
                GetComponent<MeshRenderer> ().material = materialHealth2;
            }
            else
            {
                GetComponent<MeshRenderer> ().material = materialHealth3;
            }
            if (health <= 0)
            {
                if (gameObject.GetComponent<SpawnPowerUp>() != null)
                {
                    GameManager.instance.P1Score += 1;
                    GetComponent<SpawnPowerUp>().ChooseSpawnPowerUp();
                }
                else
                {
                    GameManager.instance.P1Score += 1;
                    Destroy(gameObject); // Zerstören Sie den Stein, wenn die Gesundheit <= 0 ist
                }
 
            }
        }
    }
}