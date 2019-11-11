using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Camera.main.transform.forward * 1000);
            rb.AddForce(Camera.main.transform.up * 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
