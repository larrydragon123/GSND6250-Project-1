using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowWin : MonoBehaviour
{

    public string tag;
    public FireBallController fireBallController;
    public bool allLit;

    // Start is called before the first frame update
    void Start()
    {
        allLit = fireBallController.allLit;
    }

    // Update is called once per frame
    void Update()
    {
        allLit = fireBallController.allLit;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (allLit)
        {
            if(other.gameObject.tag == tag)
            {
                print("WIN");
            }
        }
    }
}
