using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public Vector3 startPos;
    // Start is called before the first frame update
    private void Awake()
    {
        startPos = this.transform.position;
        
    }
    private void Update()
    {
        if (Restart._restart)
        {
            this.transform.position = startPos;
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
