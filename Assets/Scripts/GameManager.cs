using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI lives;
    public TextMeshProUGUI pauseScreen;
    private float spawnRangeX = 20;
    private float spawnPosZ = 5;
    public int health;
    public int gameLaps;
    public int score;
    public List<GameObject> carPrefabs;
    public List<GameObject> powerUpPrefabs;
    public TextMeshProUGUI laps;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public TextMeshProUGUI titleScreen;
    public AudioClip crashSound;
    private AudioSource enemyAudio;
    public bool isGamePaused;
    public TextMeshProUGUI scoreEarnedText;
    public TextMeshProUGUI lapsSurvivedText;
    private float powerUpSpawnRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        enemyAudio.PlayOneShot(crashSound, 1.0f);
        scoreEarnedText.text = "Score Earned: " + score;
        lapsSurvivedText.text = "Laps Survived: " + gameLaps;
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
        StartCoroutine(PowerupSpawn());
        Health(3);
        Laps(0);
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
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

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
        lives.text = "Health: " + health;
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                Time.timeScale = 1;
                isGamePaused = false;
                pauseScreen.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                isGamePaused = true;
                pauseScreen.gameObject.SetActive(true);
            }
        }
    }


    IEnumerator SpawnEnemies()
    {
        while (isGameActive)
        {
            int index = Random.Range(0, carPrefabs.Count);
            if (gameLaps == 0)
            {
                yield return new WaitForSeconds(spawnRate);
                Instantiate(carPrefabs[index], new Vector3(spawnRangeX, 0, (Random.Range(-spawnPosZ, spawnPosZ))), carPrefabs[index].transform.rotation);
            }
            
            for(int i = 0; i < gameLaps; i++)
            {
                yield return new WaitForSeconds(spawnRate / gameLaps);
                Instantiate(carPrefabs[index], new Vector3(spawnRangeX, 0, (Random.Range(-spawnPosZ, spawnPosZ))), carPrefabs[index].transform.rotation);
            }
        }
    }
    IEnumerator PowerupSpawn()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(powerUpSpawnRate);
            int index = Random.Range(0, powerUpPrefabs.Count);
            Instantiate(powerUpPrefabs[index], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, (Random.Range(-spawnPosZ, spawnPosZ))), powerUpPrefabs[index].transform.rotation);
        }
    }
}
