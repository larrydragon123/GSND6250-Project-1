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
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            //Debug.Log("It is wroking");
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
    }


}
