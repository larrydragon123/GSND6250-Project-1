using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //if press escape key quit the game
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
