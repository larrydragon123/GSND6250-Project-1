using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{

    public bool baseRotation = true;
    public int baseRotationValue = 0;
    public int otherRotationValue = 90;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //rotate the enemy between 0 and 90 degrees
         if (baseRotation)
         {
              transform.rotation = Quaternion.Euler(0, baseRotationValue + Mathf.PingPong(Time.time * 90, otherRotationValue), 0);
         }
         else
         {
              transform.rotation = Quaternion.Euler(0, otherRotationValue + Mathf.PingPong(Time.time * 90, baseRotationValue), 0);
         }
        

    }
}
