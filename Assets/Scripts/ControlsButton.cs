using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    public GameObject controlPanel;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HowToPlayButtonPressed);
    }

    public void HowToPlayButtonPressed()
    {
        controlPanel.SetActive(true);
        titleScreen.SetActive(false);
    }
}
