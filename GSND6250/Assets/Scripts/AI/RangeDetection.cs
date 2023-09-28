using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangeDetection : MonoBehaviour
{
    private GameObject player;

    public float range = 20f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //draw the range circle
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
