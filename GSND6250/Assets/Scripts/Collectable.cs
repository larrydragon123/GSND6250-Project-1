using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //when player's nearby, press a key to collect
    //if collected, destroy object
    public float radius = 3f;
    public float distance = 2f;

    public GameObject player;
    public GameObject collectable;

    public bool isCollected = false;

    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, collectable.transform.position) < radius)
        {
            // Debug.Log("Player is nearby");
            if (Input.GetKeyDown(KeyCode.E))
            {
                isCollected = true;
                Destroy(collectable);
                // Debug.Log("Collected");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collectable.transform.position, radius);
    }

}
