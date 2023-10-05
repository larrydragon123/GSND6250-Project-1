using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float attackFrequency = 2f;
    public float overheadAttackHeight = 5f;

    public int lightableRequired = 4;
    public int lightableCount = 0;
    public bool allLit = false;

    public Light light1;
    public Light light2;
    public Transform firePoint;

    public GameObject fireBallPrefab;
    private bool isAbove = false;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        lightableCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        
        InvokeRepeating("Shoot", 0f, attackFrequency);
        Shoot();

        light2.intensity = 0;
    }

    private void Shoot()
    {
        this.GetComponent<Transform>().LookAt(player.transform);

        if (!isAbove)
        {
            Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
            isAbove = true;
        }
        else
        {
            Instantiate(fireBallPrefab, player.transform.position + new Vector3(0, overheadAttackHeight, 0), firePoint.rotation);
            isAbove = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightableCount >= lightableRequired)
        {
            Debug.Log("All Lit:" + lightableCount);
            
            allLit = true;

            Debug.Log("All Lit:" + allLit);

            light1.enabled = false;
            light2.intensity = 10;
        }
    }
}
