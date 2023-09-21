using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildStairs : MonoBehaviour
{

    public bool playerGotBuildItem = false;
    [SerializeField] private bool playerBuiltStares = false;
    [SerializeField] GameObject placeHolderStairs;
    public Collectable collectable;
    public GameObject player;
    private bool playerIsNearby = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Check if specific collectible has benn collected so that we unlock the ability for the player to spawn/build the staris.
        if(collectable == null)
        {
            //Debug.Log("It is wroking");
            playerGotBuildItem = true;
        }

        if(playerGotBuildItem == true)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    playerBuiltStares = true;
                    placeHolderStairs.SetActive(true);
                    // Debug.Log("Collected");
                }
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerIsNearby = false;
        }
    }


}
