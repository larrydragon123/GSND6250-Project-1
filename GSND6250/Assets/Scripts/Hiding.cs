using System.Collections;
using System.Collections.Generic;
using IndieMarc.EnemyVision;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    //when player come close to the object, player can press E to hide

    public float radius = 3f;
    public float distance = 2f;

    private GameObject player;

    public bool isHiding = false;

    public Vector3 beforeEnterPos;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update(){
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < radius)
        {
            // Debug.Log("Player is nearby");
            if (Input.GetKeyDown(KeyCode.E) && !isHiding)
            {
                isHiding = true;
                player.GetComponent<VisionTarget>().visible= false;
                beforeEnterPos = player.transform.position;
                player.transform.position = gameObject.transform.position;
                player.GetComponent<PlayerMovementAdvanced>().enabled = false;

            }else if(Input.GetKeyDown(KeyCode.E) && isHiding){
                isHiding = false;
                player.GetComponent<VisionTarget>().visible= true;
                player.transform.position = beforeEnterPos;
                player.GetComponent<PlayerMovementAdvanced>().enabled = true;
            }
        }
    }  

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    } 
}
