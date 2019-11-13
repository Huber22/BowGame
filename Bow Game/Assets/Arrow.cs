using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool collided = false;
    public Rigidbody rb;
    public float force;
    [SerializeField] private float baseDamage;
    public float addedDamage;
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
            Destroy(this.gameObject, 30f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
      
        if (collision.collider.tag != "Player")
        {

            collided = true;
        }
        if (collision.collider.tag == "Enemy")
        {
            
            collision.collider.GetComponent<enemy>().TakeDamage(addedDamage + baseDamage);
            this.transform.parent = collision.transform;
            rb.isKinematic = true;
            addedDamage = 0;
            baseDamage = 0;
        }
    }
 /*   public void ApplyForce(float F)
    {
        force = F;


    }*/
}
