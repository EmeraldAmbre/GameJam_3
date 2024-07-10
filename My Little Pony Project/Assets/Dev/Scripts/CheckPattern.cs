using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPattern : MonoBehaviour {

    public Transform startPoint, endPoint;
    private DrawLine drawLine;

    void Start()
    {
        drawLine = FindObjectOfType<DrawLine>();
    }

    void Update()
    {
        if (!drawLine.isDrawing)
        {
            CheckLineMatch();
        }
    }

    void CheckLineMatch()
    {
        Vector3 drawnStart = drawLine.lineRenderer.GetPosition(0);
        Vector3 drawnEnd = drawLine.lineRenderer.GetPosition(1);

        float startDistance = Vector3.Distance(drawnStart, startPoint.position);
        float endDistance = Vector3.Distance(drawnEnd, endPoint.position);

        if (startDistance < 0.1f && endDistance < 0.1f)
        {
            Debug.Log("Pattern Matched!");
        }
        else
        {
            Debug.Log("Pattern Not Matched");
        }
    }
}
