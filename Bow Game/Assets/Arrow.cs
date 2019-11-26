using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public bool collided = false;
    public Rigidbody rb;
    public float force;

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


            if (collision.collider.tag != "Player"&& collision.collider.tag != "Enemy")//TODO if enemy walks over an arrow they will still take damage once
            {

                collided = true;
            this.GetComponent<TrailRenderer>().emitting=false;
            }
        if (collision.collider.tag == "Enemy" && collided != true)
        {

            collision.collider.GetComponent<enemystats>().TakeDamage(addedDamage);
            if (collision.collider.GetComponent<enemyController>() != null)
            {
                collision.collider.GetComponent<enemyController>().SetTarget();
            }
            this.transform.parent = collision.transform;
            this.GetComponent<TrailRenderer>().emitting = false;
            Destroy(rb);
            addedDamage = 0;

            collided = true;

        }
        
    }

}
