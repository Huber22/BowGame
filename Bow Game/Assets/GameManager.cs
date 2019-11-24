using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject powerUp;
    //TODO public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPowerup(GameObject spawnpoint)
    {
        Debug.Log("Spawn");
    
        GameObject power= Instantiate(powerUp,spawnpoint.transform.position,Quaternion.identity);
        power.GetComponent<Powerup>().play = Player;
    }
}
