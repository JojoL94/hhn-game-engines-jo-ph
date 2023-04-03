using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stone : MonoBehaviour
{
    public int health = 1; // Die Anzahl der Treffer, die der Stein aushält, bevor er zerstört wird
    public Material materialHealth1;
    public Material materialHealth2;
    public Material materialHealth3;
    public Material powerUpMaterial;

    public GameObject[] powerUps;
    private void Start()
    {
        health = Random.Range(0, 4);

        bool isPowerUp = Random.Range(0, 100) > 90 ? true : false;
        if (isPowerUp)
        {
            health = 1;
            transform.AddComponent<SpawnPowerUpStone>();
            GetComponent<MeshRenderer>().material = powerUpMaterial;
        }
        else
        {

            if (health == 1)
                GetComponent<MeshRenderer>().material = materialHealth1;
            else if (health == 2)
                GetComponent<MeshRenderer>().material = materialHealth2;
            else
                GetComponent<MeshRenderer>().material = materialHealth3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Überprüfen Sie, ob die Kollision mit dem Ball stattgefunden hat
        {
            health--; // Verringern Sie die Gesundheit des Steins um 1
            if (health == 1)
                GetComponent<MeshRenderer> ().material = materialHealth1;
            else if (health == 2)
                GetComponent<MeshRenderer> ().material = materialHealth2;
            else
                GetComponent<MeshRenderer> ().material = materialHealth3;
            if (health <= 0)
            {
                if (gameObject.GetComponent<SpawnPowerUpStone>() != null)
                    GetComponent<SpawnPowerUpStone>().ChooseSpawnPowerUp(powerUps);
                else
                    Destroy(gameObject); // Zerstören Sie den Stein, wenn die Gesundheit <= 0 ist
                ScriptManager.instance.P1Score += 1;
 
            }
        }
    }
}