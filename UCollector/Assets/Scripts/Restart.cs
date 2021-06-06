using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public static bool _restart = false;

    public GameObject restratPanel;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        if (_restart)
        {
            OpenMenu();
        }
    }

    public void OpenMenu()
    {
        if (!restratPanel.activeInHierarchy)
        {
            restratPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Restartlvl()
    {
        if (restratPanel.activeInHierarchy)
        {
            restratPanel.SetActive(false);
            Time.timeScale = 1;            
            Destroy(GameObject.Find(LevelManager.levels[LevelManager.currentLevel].name + "(Clone)"));
            Instantiate(LevelManager.levels[LevelManager.currentLevel], Vector3.zero, Quaternion.identity);
            _restart = false;
            SwervingController.ReturZero = true;
            SwervingController.AllowedToMove = true;
        }
    }
   
}
