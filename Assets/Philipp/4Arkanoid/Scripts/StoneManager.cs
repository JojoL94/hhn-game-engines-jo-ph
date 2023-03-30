using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoneManager : MonoBehaviour
{
    public GameObject brick;
    public int spawnAmount;

    public Vector2 maxSpawnPos, minSpawnPos;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    // Start is called before the first frame update
    void Start()
    {
        gameWonUI.SetActive(false);
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject newBrick = Instantiate(brick, new Vector3(minSpawnPos.x+(i%10), 0, minSpawnPos.y-(0.5f*(Mathf.FloorToInt(i/10)))), new Quaternion(0,0,0,0));
            newBrick.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            Time.timeScale = 0;
            gameWonUI.SetActive(true);
        }
    }

    public void restartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
