using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootArrow : MonoBehaviour
{
    public float maxForce;
    public float arrowforce;
    public float drawRate;
    public float fireRate;//how many seconds you want to wait
    private float _nextfire;// the next time you will be able to do something
    private float _maxDamage;
    private float _damage;
    public float baseDamage=1;
    public GameObject arrowPrefab;
    public GameObject firePoint;
    public GameObject firePoint2;
    public GameObject firePoint3;
    public float multiarrow = 0;
    public Slider forceSlider;
    public GameObject displayArrow;
    public GameObject displayArrow2;
    public GameObject displayArrow3;
    // Start is called before the first frame update
    void Start()
    {
        arrowforce = 20;
        displayArrow2.SetActive(false);
        displayArrow3.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        _maxDamage = maxForce / 100f;
        forceSlider.maxValue = maxForce;
        forceSlider.value = arrowforce;
        if (Time.time >= _nextfire)
        {
            displayArrow.SetActive(true);
            if (multiarrow > 0)
            {
                displayArrow2.SetActive(true);
                if (multiarrow > 1)
                {
                    displayArrow3.SetActive(true);
                }


            }
        }
        if (Input.GetMouseButton(0)&& arrowforce <= maxForce&& Time.time>=_nextfire){//if time has passed nextfire then do something

            arrowforce=arrowforce+drawRate*Time.deltaTime;
            _damage =arrowforce / 100f;
            
            
        }
        if (Input.GetMouseButtonUp(0) && arrowforce > 20f){

            GameObject arrow = Instantiate(arrowPrefab, firePoint.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
            arrow.GetComponent<Arrow>().force = arrowforce;
            arrow.GetComponent<Arrow>().addedDamage = _damage+baseDamage;
           
            _nextfire = Time.time+fireRate;//sets nextfire to be firerate seconds after current time
            displayArrow.SetActive(false);
            

            if (multiarrow > 0)
            {
                displayArrow2.SetActive(false);
                GameObject arrow2 = Instantiate(arrowPrefab, firePoint2.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
                arrow2.GetComponent<Arrow>().force = arrowforce;
                arrow2.GetComponent<Arrow>().addedDamage = _damage + baseDamage;
                if (multiarrow > 1)
                {
                    displayArrow3.SetActive(false);
                    GameObject arrow3 = Instantiate(arrowPrefab, firePoint3.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
                    arrow3.GetComponent<Arrow>().force = arrowforce;
                    arrow3.GetComponent<Arrow>().addedDamage = _damage + baseDamage;
                }

                
            }
            arrowforce = 20;

        }
    }
    void upgradeArrow()
    {
        //arrowPrefab.GetComponent<Arrow>().baseDamage++;
    }
    void upgradeDraw()
    {
        drawRate = drawRate + 5;
    }
    void upgradeForce()
    {
        maxForce = maxForce + 200;
    }
    void upgradeFireRate()
    {
        fireRate = fireRate - .2f;
    }
}
