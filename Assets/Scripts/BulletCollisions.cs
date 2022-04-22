using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    private GameManager gameManager;
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.UpdateScore(5);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy 2"))
        {
            gameManager.UpdateScore(10);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy 3"))
        {
            gameManager.UpdateScore(-5);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
