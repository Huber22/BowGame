using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemystats : MonoBehaviour
{

    public GameObject powerUp;
    [SerializeField] private float _maxhealth;
    [SerializeField ] private float _health;
    [SerializeField] private int _chance;
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
        Debug.Log("Die");
        if (Random.Range(1, _chance) == 1)
        {
            GameObject power = Instantiate(powerUp, this.transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        _health = _health - damage;
    }

}
