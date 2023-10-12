using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public GameObject[] _objectsToConnect;

    private LineRenderer _lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _objectsToConnect.Length; i++)
        {
            _lineRenderer.SetPosition(i, _objectsToConnect[i].transform.position);
        }
    }
}
