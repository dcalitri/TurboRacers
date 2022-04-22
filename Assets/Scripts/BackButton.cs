using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button button;
    public GameObject controlPanel;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BackButtonPressed);
    }

    public void BackButtonPressed()
    {
        titleScreen.SetActive(true);
        controlPanel.SetActive(false);
    }
}
