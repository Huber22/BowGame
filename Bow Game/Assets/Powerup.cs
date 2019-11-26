using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    GameManager GameManager;
  void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
    }
    

   void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            GameManager.PickupPowerup();
            Destroy(this.gameObject,.01f);
        }
    }
}
