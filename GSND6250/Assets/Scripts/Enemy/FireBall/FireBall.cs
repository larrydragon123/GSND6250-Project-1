using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    public float timeToDestroy = 5f;
    public float fireOffset = 3f;

    private Vector3 target;

    public GameObject fireEffect;

    public FireBallController fireBallController;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        fireBallController = GameObject.Find("BOSS").GetComponent<FireBallController>();
        transform.LookAt(target);
        Destroy(gameObject, timeToDestroy);
    }
    void Update()
    {
        //move towards the target and do not stop

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit the player");
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            // Destroy(gameObject);
        }
        if (other.CompareTag("Lightable"))
        {
            //light the torch
            other.GetComponent<MeshCollider>().enabled = false;
            fireBallController.lightableCount++;
            Debug.Log("Light the torch");
            GameObject fire = Instantiate(fireEffect, other.transform.position + new Vector3(0, fireOffset, 0), Quaternion.identity);
            fire.transform.Rotate(-90, 0, 0);
            Destroy(gameObject);
        }
        
    }
}
