using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health = 1; // Die Anzahl der Treffer, die der Stein aushält, bevor er zerstört wird

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball")) // Überprüfen Sie, ob die Kollision mit dem Ball stattgefunden hat
        {

            health--; // Verringern Sie die Gesundheit des Steins um 1
            if (health <= 0)
            {
                Destroy(gameObject); // Zerstören Sie den Stein, wenn die Gesundheit <= 0 ist
            }
        }
    }
}