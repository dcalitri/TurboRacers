using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.Health(-1);
            if ((gameManager.health == 0) && other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                gameManager.GameOver();
            }
            Destroy(gameObject);
        }
    }
}
