using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootArrow : MonoBehaviour
{
    public float maxForce;
    public float arrowforce;
    public float drawRate;
    public float fireRate;
    private float _nextfire;
    private float _maxDamage;
    private float _damage;
    public GameObject arrowPrefab;
    public GameObject firePoint;
    public Slider forceSlider;
    public GameObject displayArrow;
    // Start is called before the first frame update
    void Start()
    {
        arrowforce = 20;
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
        }
        if (Input.GetMouseButton(0)&& arrowforce <= maxForce&& Time.time>=_nextfire){

            arrowforce=arrowforce+drawRate*Time.deltaTime;
            _damage =arrowforce / 100f;
            
            
        }
        if (Input.GetMouseButtonUp(0) && arrowforce > 20f){

            GameObject arrow = Instantiate(arrowPrefab, firePoint.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
            arrow.GetComponent<Arrow>().force = arrowforce;
            arrow.GetComponent<Arrow>().addedDamage = _damage;
            arrowforce = 20;
            _nextfire = Time.time+fireRate;
            displayArrow.SetActive(false);

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
