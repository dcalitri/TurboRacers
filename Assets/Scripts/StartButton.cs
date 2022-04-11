using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GameStart);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void GameStart()
    {
        gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
}