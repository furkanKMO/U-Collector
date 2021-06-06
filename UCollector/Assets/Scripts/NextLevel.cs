using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextLevel : MonoBehaviour
{
    public GameObject LvlEnd;
    public TMP_Text LevelText;
    public GameObject oldlvl,currentLevel;
    public static int levelName=1;

    void Start()
    {

    }
    private void Update()
    {
        LevelText.text = "Level " + levelName;
    }



    public void OpenMenu()
    {
        if (!LvlEnd.activeInHierarchy)
        {
            
            LvlEnd.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void NextLvl()
    {
        if (LvlEnd.activeInHierarchy)
        {
            LvlEnd.SetActive(false);
            Time.timeScale = 1;
            //oldlvl = LevelManager.levels[LevelManager.currentLevel - 1];
            currentLevel =LevelManager.levels[ LevelManager.currentLevel];
            oldlvl = currentLevel;
            int randomlvl = Random.Range(0, 10);
            Debug.Log(LevelManager.currentLevel);
            if (levelName<10)
            {
                oldlvl = LevelManager.levels[LevelManager.currentLevel ];
                LevelManager.currentLevel++;
                currentLevel = LevelManager.levels[LevelManager.currentLevel];
                levelName++;
                Destroy(GameObject.Find(oldlvl.name+ "(Clone)"));
                Instantiate(LevelManager.levels[LevelManager.currentLevel], Vector3.zero, Quaternion.identity);
            }
            else
            {
                Destroy(GameObject.Find(currentLevel.name + "(Clone)"));
                currentLevel = LevelManager.levels[randomlvl];
                LevelManager.currentLevel = randomlvl;
                levelName++;
                Instantiate(LevelManager.levels[LevelManager.currentLevel], Vector3.zero, Quaternion.identity);
            }
            
           // oldlvl.SetActive(false);
           // currentLevel.SetActive(true);
            this.transform.position = Vector3.zero;
            SwervingController._newXPos = 0;
           
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            OpenMenu();
        }
    }

}