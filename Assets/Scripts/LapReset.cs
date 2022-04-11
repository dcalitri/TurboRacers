using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapReset : MonoBehaviour
{
    private Vector3 startPos;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - 170)
        {
            transform.position = startPos;
            gameManager.Laps(1);
        }
    }
}
