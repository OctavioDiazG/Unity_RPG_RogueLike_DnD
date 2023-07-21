using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject InventoryPanel;
    public bool isPaused = false;

    private void Awake()
    {
        isPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!PausePanel.activeSelf)
            {
                PausePanel.SetActive(true);
                Time.timeScale = .001f;
                isPaused = true;
            }
            else
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InventoryPanel.activeSelf)
            {
                InventoryPanel.SetActive(true);
                Time.timeScale = .001f;
                isPaused = true;
            }
            else
            {
                InventoryPanel.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
}
