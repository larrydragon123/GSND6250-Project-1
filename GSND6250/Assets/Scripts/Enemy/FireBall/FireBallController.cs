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
    public Transform firePoint;

    public GameObject fireBallPrefab;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        lightableCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        
        InvokeRepeating("Shoot", 0f, attackFrequency);
        Shoot();
    }

    private void Shoot()
    {
        this.GetComponent<Transform>().LookAt(player.transform);

        //randomly shoot from either the firepoint or aboveplayer
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Instantiate(fireBallPrefab, player.transform.position + new Vector3(0, overheadAttackHeight, 0), firePoint.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightableCount >= lightableRequired)
        {
            Debug.Log("All Lit:" + lightableCount);
        }
    }
}
