using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public  List<GameObject> levelList = new List<GameObject>();
    public static List<GameObject> levels = new List<GameObject>();
    public static int currentLevel=0;

   
    private void Start()
    {
        levels = levelList;
       
        Instantiate(levelList[currentLevel], Vector3.zero, Quaternion.identity);
        
    }
    

}
