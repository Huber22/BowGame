using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fist : MonoBehaviour
{
    public float attackDamage;
    private float _hashit=.5f;
    private float _canhit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player"&& Time.time>=_canhit)
        {
            _canhit = Time.time + _hashit;
            hit.GetComponent<Player>().takeDamage(attackDamage);
        }
    }
}
