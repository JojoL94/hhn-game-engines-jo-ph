using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps;
    private GameObject selectedElement;
    public void ChooseSpawnPowerUp()
    {
        selectedElement = powerUps[Random.Range(0, powerUps.Length)];
        GameObject powerUpStart = Instantiate(selectedElement, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
    }
}
