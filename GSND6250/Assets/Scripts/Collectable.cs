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

    public BuildStairs buildStairs;

    public bool isCollected = false;

    public GameObject instructionPanel;
    public GameObject pressE;
    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, collectable.transform.position) < radius)
        {
            // Debug.Log("Player is nearby");
            instructionPanel.SetActive(true);
            pressE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isCollected = true;
                Destroy(collectable);
                instructionPanel.SetActive(false);
                pressE.SetActive(false);
            }
        }else{
            instructionPanel.SetActive(false);
            pressE.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(collectable.transform.position, radius);
    }

}
