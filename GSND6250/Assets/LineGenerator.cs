using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown (0)){
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        if(Input.GetMouseButtonUp (0)){
            activeLine = null;
        }

        if(activeLine != null){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
        
    }
}
