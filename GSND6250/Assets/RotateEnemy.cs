using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{

    public bool baseRotation = true;
    public int baseRotationValue = -45;
    public int otherRotationValue = 135;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        

        if (baseRotation == true && transform.rotation.y < otherRotationValue)
        {
           transform.Rotate(0, 0.5f, 0);
            print(transform.rotation);
            //transform.eulerAngles = new Vector3(0, 1, 0);
            if (transform.rotation.y == otherRotationValue)
            {
                print("REVERSE ROATION");
                baseRotation = false;
            }
        }

        

        if (baseRotation == false && transform.rotation.y > baseRotationValue)
        {
            transform.Rotate(0, -0.5f, 0);
            //transform.eulerAngles = new Vector3(0, -1, 0);
            if (transform.rotation.y == baseRotationValue)
            {
                baseRotation = true;
            }
        }
    }
}
