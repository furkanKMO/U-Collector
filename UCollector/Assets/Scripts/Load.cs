using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void Awake()
    {
        GameLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("PlayerPositionZ"))
        {
            this.gameObject.transform.position = new Vector3(0, 0, PlayerPrefs.GetFloat("PlayerPositionZ"));
            LevelManager.currentLevel = PlayerPrefs.GetInt("PlayerLevel");
            NextLevel.levelName = PlayerPrefs.GetInt("LevelName");

        }
      
       

    }
}
