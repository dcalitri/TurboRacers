using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI lives;
    private float spawnRangeX = 20;
    private float spawnPosZ = 5;
    public int health;
    public int gameLaps;
    public List<GameObject> carPrefabs;
    public TextMeshProUGUI laps;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public TextMeshProUGUI titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnEnemies());
        Health(3);
        Laps(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Health(int healthToLose)
    {
        health -= 1;
        lives.text = "Health: " + health;
    }

    public void Laps(int lapsToAdd)
    {
        gameLaps += lapsToAdd;
        laps.text = "Laps: " + gameLaps;
    }
   
    IEnumerator SpawnEnemies()
    {
       while (isGameActive)
       {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, carPrefabs.Count);
            Instantiate(carPrefabs[index], new Vector3(spawnRangeX, 0, (Random.Range(-spawnPosZ, spawnPosZ))), carPrefabs[index].transform.rotation);
       }
    }
}
