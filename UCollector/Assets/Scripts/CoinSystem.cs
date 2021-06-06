using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinSystem : MonoBehaviour
{
    public static int coins;
    public TMP_Text coinText;
    public AudioSource audioS;
    public AudioClip coin;
    private void Awake()
    {
        coins = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //collect
            coins += 10;
            coinText.text = coins.ToString();
            audioS.clip = coin;
            audioS.Play();
            other.transform.parent.gameObject.SetActive(false);
        }
    }
}
