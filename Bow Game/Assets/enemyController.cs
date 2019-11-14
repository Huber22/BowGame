using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public bool Melee;
    public float attackRate;
    public float attackDamage;
    public float attackRange=3f;
    private float _nextattack;
    public bool Aggro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Attack();


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

            SetTarget();
        }
    }
    public void SetTarget()
    {
        Aggro = true;
    }
    void Movement()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) <= 2.5f)
        {
            agent.isStopped = true;

        }
        else
        {
            agent.isStopped = false;
        }

        if (Aggro == true)
        {
            agent.SetDestination(target.transform.position);
        }
    }
    void Attack()
    {

        if (Vector3.Distance(this.transform.position, target.transform.position) <= attackRange&& Time.time>= _nextattack)
        {
            target.GetComponent<Player>().takeDamage(attackDamage);

            _nextattack = Time.time + attackRate;

        }
    }

    /*
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            
            agent.SetDestination(col.transform.position);
        }
    }
    public void SetTarget()
    {
        agent.SetDestination(target.transform.position);
    }
    *///detects player when shot or in detection radius but stops when player leaves

}
