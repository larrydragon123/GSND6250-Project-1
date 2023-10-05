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

    //All for win state
    public Light light1;
    public Light light2;
    public Light light3;


    public Transform firePoint;

    public GameObject fireBallPrefab;

    private AudioSource audioSource;
    public AudioClip frontSpeech;
    public AudioClip straightFireBall;
    public AudioClip aboveFireBall;

    private bool isAbove = false;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lightableCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        //after play the audio, shoot the fireball

        StartCoroutine(ShootFireBall());

        light2.intensity = 0;
        light3.intensity = 0;
    }

    IEnumerator ShootFireBall()
    {
        audioSource.PlayOneShot(frontSpeech);
        yield return new WaitForSeconds(frontSpeech.length);
        InvokeRepeating("Shoot", 0f, attackFrequency);
    }




    private void Shoot()
    {
        this.GetComponent<Transform>().LookAt(player.transform);

        //randomly shoot from either the firepoint or aboveplayer
        if (!isAbove)
        {
            Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
            audioSource.PlayOneShot(straightFireBall);
            isAbove = true;
        }
        else
        {
            Instantiate(fireBallPrefab, player.transform.position + new Vector3(0, overheadAttackHeight, 0), firePoint.rotation);
            audioSource.PlayOneShot(aboveFireBall);
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
            //stop repeating
            CancelInvoke();

            Debug.Log("All Lit:" + allLit);

            light1.enabled = false;
            light2.intensity = 10;
            light3.intensity = 10;
        }
    }
}
