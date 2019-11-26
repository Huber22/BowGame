using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemystats : MonoBehaviour
{

    public GameObject powerUp;
    [SerializeField] public float _maxhealth;
    [SerializeField ] public float _health;
    [SerializeField] private int _chance;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _health = _maxhealth;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
       
        gameManager.assignMostrecentenemy(this.gameObject);
    }

}
