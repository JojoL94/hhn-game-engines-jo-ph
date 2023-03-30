using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUpStone : MonoBehaviour
{
    private GameObject selectedElement;
    public void ChooseSpawnPowerUp(GameObject[] powerUps)
    {
        selectedElement = powerUps[Random.Range(0, powerUps.Length)];
        GameObject powerUpStart = Instantiate(selectedElement, transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(gameObject);
    }
}
