using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    [SerializeField] private LineRenderer _playerLineRenderer;
    private LineRenderer _symbolLineRenderer;
    [SerializeField] private int _symbolLayer;

    private List<Vector3> points = new List<Vector3>();

    void Update() {

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects) {

            if (obj.layer == _symbolLayer) { _symbolLineRenderer = obj.GetComponent<LineRenderer>(); }

        }
        if (_symbolLineRenderer == null) return;
        if (Input.GetMouseButtonDown(0)) {

            Vector3 mousePosition = Input.mousePosition;

            mousePosition.z = 10.0f;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            points.Add(worldPosition);

            _playerLineRenderer.positionCount = points.Count;
            _playerLineRenderer.SetPositions(points.ToArray());

        }

        if (_playerLineRenderer.positionCount > _symbolLineRenderer.positionCount) _playerLineRenderer.positionCount = 0;

    }
}
