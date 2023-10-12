using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangeDetection : MonoBehaviour
{
    private GameObject player;

    public float range = 20f;
    public float tooFarRange = 25f;
    public GameObject tooFar;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        tooFar.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            Debug.Log("Player is in range");
        }else
        {
            Debug.Log("Player is not in range");
            //restart the game
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        if(Vector3.Distance(transform.position, player.transform.position) > tooFarRange)
        {
            Debug.Log("Player is too far");
            tooFar.SetActive(true);
        }else{
            tooFar.SetActive(false);
        }
    }

    //draw the range circle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
