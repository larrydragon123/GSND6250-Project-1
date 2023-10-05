using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWin : MonoBehaviour
{

    // public string tag;
    public FireBallController fireBallController;

    public GameObject center;

    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTriggered)
        {
            moveTheCenter();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (fireBallController.allLit)
        {
            if(other.gameObject.tag == "Player")
            {
                isTriggered = true;
                fireBallController.setIsTrigger();
                
            }
        }
    }

    private void moveTheCenter()
    {
        center.transform.position = Vector3.Lerp(center.transform.position, new Vector3(center.transform.position.x, center.transform.position.y - 3, center.transform.position.z), 0.01f);
    }
}
