using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
     public int startRotationValue = 0;
     public int endRotationValue = 90;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
          transform.rotation = Quaternion.Euler(0, Mathf.PingPong(Time.time * 90, endRotationValue - startRotationValue) + startRotationValue, 0);         
        

    }
}
