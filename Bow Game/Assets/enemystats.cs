using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemystats : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float _maxhealth;
    [SerializeField ] private float _health;
    [SerializeField] private float _chance;
    [SerializeField] private Slider _Hp;
    // Start is called before the first frame update
    void Start()
    {
        _health = _maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        _Hp.maxValue = _maxhealth;
        _Hp.value = _health;
        if (_health <= 0)
        {
            Die();
        }   
    }

    void Die()
    {
        if (Random.Range(1, _chance) == 1)
        {
            gameManager.SpawnPowerup(this.gameObject);
        }
        Destroy(this.gameObject);
    }
    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        _health = _health - damage;
    }

}
