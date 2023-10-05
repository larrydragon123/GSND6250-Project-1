using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;

    public float timeToDestroy = 3f;
    private Vector3 target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
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
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
        // if (other.CompareTag("Torch"))
        // {
        //     //light the torch
        //     Destroy(gameObject);
        // }
        
    }
}
