using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    private CandleController candleController;
    // Start is called before the first frame update
    void Start()
    {
        candleController = transform.parent.GetComponent<CandleController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            candleController.LightNextCandle();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
