using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpenClose : MonoBehaviour
{
    public GameObject panel;
    public void OpenMenu() 
    {
        if (!panel.activeInHierarchy)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void CloseMenu()
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
