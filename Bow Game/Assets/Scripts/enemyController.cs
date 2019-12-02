using System;
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
   // public float attackDamage;
    public float attackRange=3f;
    public float stopDistance = 2.5f;
    public float stopDistanceRanged = 6f;
    public float rangedAttackRange = 10f;
    private float _nextattack;
    public bool Aggro;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Melee == true)
        {
            Movement();
            Attack();
        }
        else if (Melee == false)
        {
            RangedMovement();
            RangedAttack();
        }


    }

    private void RangedAttack()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) <= rangedAttackRange && Time.time >= _nextattack)
        {
            Debug.Log("ranged attack");
            //raycast

        }
    }

    private void RangedMovement()
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) <= stopDistanceRanged)
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
            transform.LookAt(target.transform.position);
        }
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
        if (Vector3.Distance(this.transform.position, target.transform.position) <= stopDistance)
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
            transform.LookAt(target.transform.position);
        }
    }
    void Attack()
    {

        if (Vector3.Distance(this.transform.position, target.transform.position) <= attackRange&& Time.time>= _nextattack)
        {
            
            anim.SetTrigger("Attack");
            //target.GetComponent<Player>().takeDamage(attackDamage);

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
