using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGame() 
    {
        
        Vector3 playerPosition = this.gameObject.transform.position;
        PlayerPrefs.SetFloat("PlayerPositionZ", playerPosition.z);
        PlayerPrefs.SetInt("PlayerLevel", LevelManager.currentLevel);
        PlayerPrefs.SetInt("LevelName", NextLevel.levelName);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag=="Save")
        {
            SaveGame();
        }
    }
}
