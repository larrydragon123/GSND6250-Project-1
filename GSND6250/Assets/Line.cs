using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos){
        if(points == null){
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }
        if(Vector2.Distance(points.Last(), mousePos) > .1f){
            SetPoint(mousePos);
        }
    }
    void SetPoint(Vector2 point){
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
