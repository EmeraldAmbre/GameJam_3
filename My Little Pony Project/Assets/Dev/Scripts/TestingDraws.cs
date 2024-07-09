using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDraws : MonoBehaviour {

    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_pencilTip;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private List<List<Vector3>> m_testMoves;

    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] Vector3 m_playerOffset = new(-4.75f, 4.75f, 0);

    private List<Vector3> _positions;

    public List<Vector3> _points;
    private int _currentPointIndex = 0;

    public TestingDraws() {
        
        int index = Random.Range(0, m_testMoves.Count);
        _points = m_testMoves[index];

    }

    void Start() {

        m_pencilTip.transform.position = m_player.transform.position + m_playerOffset;
        _positions = new List<Vector3>();
        _positions.Add(m_pencilTip.transform.position);
        m_lineRenderer.positionCount = 0;
        m_lineRenderer.SetPosition(0, m_pencilTip.transform.position);

    }

    void Update() {
        
        if (_currentPointIndex >= _points.Count) return;

        Vector3 target = _points[_currentPointIndex];

        m_pencilTip.transform.position = Vector3.MoveTowards(m_pencilTip.transform.position, target, m_moveSpeed * Time.deltaTime);

        AddPointToLineRenderer(m_pencilTip.transform.position);

        if (m_pencilTip.transform.position == target) { _currentPointIndex += 1; }

    }

    void AddPointToLineRenderer(Vector3 point) {

        m_lineRenderer.positionCount += 1;
        m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, point);

    }
}
