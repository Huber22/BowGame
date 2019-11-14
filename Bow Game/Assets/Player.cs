using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    [SerializeField] private float _health;
    public float healDelay=2f;
    private float nextHeal;
    public float healRate=10f;
    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextHeal&&_health<maxHealth)
        {
            _health += healRate * Time.deltaTime;
            Debug.Log(_health);
        }
        if (_health <= 0)
        {
            Die();
        }
    }
    public void takeDamage(float damage)
    {
        _health = _health - damage;
        Debug.Log(_health);
        nextHeal = Time.time + healDelay;
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}
