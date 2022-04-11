using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip crashSound;
    private AudioSource enemyAudio;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.Health(-1);
            enemyAudio.PlayOneShot(crashSound, 1.0f);
            if ((gameManager.health == 0) && other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                gameManager.GameOver();
            }
        }
    }
}
