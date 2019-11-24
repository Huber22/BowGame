using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject play;
    public ShootArrow arrowUps;
    public Player healthUps;
    public PlayerMove moveUps;
    private int percentile;

    private int _drawRateLevel;
    private int _drawRateMax;

    private int _drawLevel;
    private int _drawMax;

    private int _reloadLevel;
    private int _reloadMax;

    private int _arrowLevel;
    private int _arrowMax;

    private int _healthLevel;
    private int _healthMax;

    private int _healthDelayLevel;
    private int _healthDelayMax;

    private int _healthRateLevel;
    private int _healthRateMax;

    private int _SpeedLevel;
    private int _SpeedMax;

    private int _heightLevel;
    private int _heightMax;

    private int _jumpLevel;
    private int _jumpMax;
    // Start is called before the first frame update
    void Start()
    {
        arrowUps = play.GetComponentInChildren<ShootArrow>();
        healthUps = play.GetComponent<Player>();
        moveUps = play.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupPowerup()
    {
        percentile = Random.Range(1, 101);
        Debug.Log(percentile);
        //max draw
        if (percentile >= 1 && percentile <= 13)//drawrate
        {
            Debug.Log("drawrate");
        }
         else if (percentile >= 14 && percentile <= 21)//max drW
        {
            arrowUps.maxForce += 250;
            Debug.Log("maxdraw");
        }
        else if (percentile >= 22 && percentile <= 33)//reload speed
        {
            Debug.Log("reload speed");
        }
        else if (percentile >= 34 && percentile <= 35)//arrows at once
        {
            Debug.Log("multiarrow");
        }
        else if (percentile >= 36 && percentile <= 45)//max health
        {
            Debug.Log("max health");
        }
        else if (percentile >= 46 && percentile <= 47)//heal delay
        {
            Debug.Log("heal delay");
        }
        else if (percentile >= 48 && percentile <= 50)//heal rate
        {
            Debug.Log("heal rate");
        }
        else if (percentile >= 51 && percentile <= 63)//movement speed
        {
            Debug.Log("movement speed");
        }
        else if (percentile >= 64 && percentile <= 70)//jump height
        {
            Debug.Log("jump height");
        }
        else if (percentile >= 71 && percentile <= 73)//double jump
        {
            Debug.Log("double jump");
        }
        else if (percentile >= 74 && percentile <= 85)//base damage
        {
            Debug.Log("increase damage");
        }
        else if (percentile >= 86 && percentile <= 88)//fire
        {
            Debug.Log("Fire");
        }
        else if (percentile >= 89 && percentile <= 93)//electric
        {
            Debug.Log("electro");
        }
        else if (percentile >= 94 && percentile <= 98)//poison
        {
            Debug.Log("poison");
        }
        else if (percentile >= 99 && percentile <= 100)//explosive
        {
            Debug.Log("explode");
        }


        

        Destroy(this.gameObject, .5f);
        
    }
   void OnTriggerEnter(Collider Col)
    {
        if (Col.tag == "Player")
        {
            PickupPowerup();
        }
    }
}
