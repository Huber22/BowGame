using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public float arrowforce;
    public GameObject arrowPrefab;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Instantiate(arrowPrefab, firePoint.transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
        }
    }
}
