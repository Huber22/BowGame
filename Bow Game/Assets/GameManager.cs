using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject play;
    public ShootArrow arrowUps;
    public Player healthUps;
    public PlayerMove moveUps;
    private GameObject _displayEnemy;
    public Slider recentHealth;
    public int maximumPowerups=0;
    public int totalPowerups = 0;
    public bool noMorePower=false;
    private int percentile;

    private int _drawRateLevel = 0;
    private int _drawRateMax = 20;

    private int _drawLevel = 0;
    private int _drawMax = 18;

    private int _reloadLevel = 0;
    private int _reloadMax = 14;

    private int _arrowLevel = 0;
    private int _arrowMax = 2;

    private int _healthLevel = 0;
    private int _healthMax = 10;

    private int _healthDelayLevel = 0;
    private int _healthDelayMax = 9;

    private int _healthRateLevel = 0;
    private int _healthRateMax = 6;

    private int _SpeedLevel = 0;
    private int _SpeedMax = 4;

    private int _heightLevel = 0;
    private int _heightMax = 4;

    private int _jumpLevel = 0;
    private int _jumpMax = 2;

    private int _damageLevel = 0;
    private int _damageMax = 10;

    private bool _fire = false;
    private bool _electric = false;
    private bool _poison = false;
    private bool _explosive = false;
    // Start is called before the first frame update
    void Start()
    {
        arrowUps = play.GetComponentInChildren<ShootArrow>();
        healthUps = play.GetComponent<Player>();
        moveUps = play.GetComponent<PlayerMove>();
        maximumPowerups = _arrowMax + _damageMax + _drawMax + _drawRateMax + _healthDelayMax + _healthMax + _healthRateMax + _heightMax + _jumpMax + _reloadMax + _SpeedMax + 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_displayEnemy!= null)
        {
            recentHealth.maxValue = _displayEnemy.GetComponent<enemystats>()._maxhealth;
            recentHealth.value = _displayEnemy.GetComponent<enemystats>()._health;
        }
    }

    public void PickupPowerup()
    {

        percentile = Random.Range(1, 101);

        Debug.Log(percentile);
        //max draw
        if (percentile >= 1 && percentile <= 13 && _drawRateLevel < _drawRateMax)//drawrate
        {

            arrowUps.drawRate += 150;
            Debug.Log("drawrate");
            _drawRateLevel = _drawRateLevel + 1;
            totalPowerups = totalPowerups + 1;





        }
        else if (percentile >= 14 && percentile <= 21 && _drawLevel < _drawMax)//max draw
        {


            arrowUps.maxForce += 250;
            Debug.Log("maxdraw");
            _drawLevel = _drawLevel + 1;
            totalPowerups = totalPowerups + 1;


        }
        else if (percentile >= 22 && percentile <= 33 && _reloadLevel < _reloadMax)//reload speed
        {
            arrowUps.fireRate -= .2f;
            Debug.Log("reload speed");
            totalPowerups = totalPowerups + 1;
            _reloadLevel++;

        }
        else if (percentile >= 34 && percentile <= 35 && _arrowLevel < _arrowMax)//arrows at once
        {
            //TODO create multiarrow functionality
            Debug.Log("multiarrow");
            totalPowerups = totalPowerups + 1;
            _arrowLevel++;

        }
        else if (percentile >= 36 && percentile <= 45 && _healthLevel < _healthMax)//max health
        {
            healthUps.maxHealth += 100;
            Debug.Log("max health");
            totalPowerups = totalPowerups + 1;
            _healthLevel++;

        }
        else if (percentile >= 46 && percentile <= 47 && _healthDelayLevel < _healthDelayMax)//heal delay
        {
            healthUps.healDelay -= 1;
            Debug.Log("heal delay");
            totalPowerups = totalPowerups + 1;
            _healthDelayLevel++;

        }
        else if (percentile >= 48 && percentile <= 50 && _healthRateLevel < _healthRateMax)//heal rate
        {
            healthUps.healRate *= 2;
            Debug.Log("heal rate");
            totalPowerups = totalPowerups + 1;
            _healthRateLevel++;

        }
        else if (percentile >= 51 && percentile <= 63 && _SpeedLevel < _SpeedMax)//movement speed
        {
            moveUps.walkSpeed += 2;   
            Debug.Log("movement speed");
            totalPowerups = totalPowerups + 1;
            _SpeedLevel++;

        }
        else if (percentile >= 64 && percentile <= 70 && _heightLevel < _heightMax)//jump height
        {
            moveUps.jumpMultiplier += 5;
            Debug.Log("jump height");
            totalPowerups = totalPowerups + 1;
            _heightLevel++;


        }
        else if (percentile >= 71 && percentile <= 73 && _jumpLevel < _jumpMax)//double jump
        {
            //todo write double jump
            Debug.Log("double jump");
            totalPowerups = totalPowerups + 1;
            _jumpLevel++;
            PickupPowerup();//Get rid of this if doublejump is finished;

        }
        else if (percentile >= 74 && percentile <= 85 && _damageLevel < _damageMax)//base damage
        {
            arrowUps.baseDamage += 1;
            Debug.Log("increase damage");
            totalPowerups = totalPowerups + 1;
            _damageLevel++;

        }
        else if (percentile >= 86 && percentile <= 88 && _fire != true)//fire
        {

            Debug.Log("Fire");
            _fire = true;
            totalPowerups = totalPowerups + 1;
            PickupPowerup();//Get rid of this if fire is finished;

        }
        else if (percentile >= 89 && percentile <= 93 && _electric != true)//electric
        {

            Debug.Log("electro");
            _electric = true;
            totalPowerups = totalPowerups + 1;
            PickupPowerup();//Get rid of this if electric is finished;

        }
        else if (percentile >= 94 && percentile <= 98 && _poison != true)//poison
        {

            Debug.Log("poison");
            _poison = true;
            totalPowerups = totalPowerups + 1;
            PickupPowerup();//Get rid of this if poison is finished;

        }
        else if (percentile >= 99 && percentile <= 100 && _explosive != true)//explosive
        {

            _explosive = true;
            Debug.Log("explode");
            totalPowerups = totalPowerups + 1;
            PickupPowerup();//Get rid of this if explosive is finished;

        }
        else
        {
            if (totalPowerups < maximumPowerups)
            {
                PickupPowerup();
            }
            else
            {
                Debug.Log("Max powerups");
            }
        }







    }

    public void assignMostrecentenemy(GameObject Recent)
    {
        _displayEnemy = Recent;
    }

}
