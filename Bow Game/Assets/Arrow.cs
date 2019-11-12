using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool collided = false;
    public Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(Camera.main.transform.forward * force);
            rb.AddForce(Camera.main.transform.up * 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collided==false)
        {
            this.transform.forward = Vector3.Slerp(this.transform.forward, rb.velocity.normalized, Time.deltaTime);
        }
        else
        {
            this.transform.forward = this.transform.forward;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
      
        if (collision.collider.tag != "Player")
        {
            Debug.Log("collided with" + collision.collider.name);
            collided = true;
        }
    }
 /*   public void ApplyForce(float F)
    {
        force = F;


    }*/
}
