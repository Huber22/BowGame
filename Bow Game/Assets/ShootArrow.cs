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
    public float nextfire;
    [SerializeField]private float _maxDamage;
    [SerializeField] private float _damage;
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
        if (Time.time >= nextfire)
        {
            displayArrow.SetActive(true);
        }
        if (Input.GetMouseButton(0)&& arrowforce <= maxForce&& Time.time>=nextfire){

            arrowforce=arrowforce+drawRate;
            _damage =arrowforce / 100f;
            
            
        }
        if (Input.GetMouseButtonUp(0) && arrowforce > 0){

            GameObject arrow = Instantiate(arrowPrefab, firePoint.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
            arrow.GetComponent<Arrow>().force = arrowforce;
            arrow.GetComponent<Arrow>().addedDamage = _damage;
            arrowforce = 20;
            nextfire = Time.time+fireRate;
            displayArrow.SetActive(false);
        }
    }
}
