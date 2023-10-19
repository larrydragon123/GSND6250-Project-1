using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int state;

    public string text;
    private GameObject player;
    public GameObject parentObject;


    public Material highlightMaterial;
    public Material defaultMaterial;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnClick()
    {
        if (this.tag == "Mushroom")
        {
            player.GetComponent<PlayerSanityStats>().NextState();
            Destroy(this.gameObject);
        }
    }



    private void Update()
    {

    }
}
