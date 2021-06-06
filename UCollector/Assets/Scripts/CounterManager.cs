using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CounterManager : MonoBehaviour
{
    public static bool CounterFail = false;
    

    private int insidecounter = 0,once=0;
    public TMP_Text CounterText;
    public int expectedCount;
    
    public GameObject Bridge,CounterLine;
    private bool active=false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterLine.GetComponent<CounterBoxActivation>().isActivated)
        {
            active = true;
        }
        else
        {
            active = false;
        }
        CounterText.text = insidecounter.ToString()+"/"+expectedCount.ToString();
        if ((!SwervingController.AllowedToMove)&& active)
        {
            if ( once==0)
            {
                StartCoroutine(Waiter());

                once++;
            }
            if (insidecounter >= expectedCount)
            {
                StopCoroutine(Waiter());
                SwervingController.AllowedToMove = true;
                Bridge.SetActive(true);
                CounterLine.SetActive(false);
                CounterLine.GetComponent<CounterBoxActivation>().isActivated = false;

            }

        }
        if (Restart._restart)
        {
            insidecounter = 0;
            once = 0;
            active = false;
            Bridge.SetActive(false);
            CounterLine.SetActive(true);
            CounterLine.GetComponent<CounterBoxActivation>().isActivated = false;

        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        
            if (coll.gameObject.tag == "Prop")
            {
            coll.gameObject.GetComponent<SphereCollider>().enabled = false;
            insidecounter++;
            }
    }
    
    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(6);
        if (insidecounter < expectedCount)
        {
            Restart._restart = true;
        }
    }
}
