using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public LineRenderer lineRenderer;
    public bool isDrawing = false;
    private Vector3 startMousePos, endMousePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startMousePos.z = 0;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, startMousePos);
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            endMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endMousePos.z = 0;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, endMousePos);
        }

        if (Input.GetMouseButtonUp(0) && isDrawing)
        {
            isDrawing = false;
        }
    }
}
