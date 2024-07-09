using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDraws : MonoBehaviour {

    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_pencilTip;
    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private List<Vector3> m_testMoves;

    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] Vector3 m_playerOffset = new(-4.75f, 4.75f, 0);

    public List<Vector3> _positions;
    private Vector3 _target;

    private int _currentPointIndex = 0;

    void Start() {

        m_lineRenderer.enabled = true;
        m_pencilTip.GetComponent<SpriteRenderer>().enabled = true;
        m_pencilTip.GetComponent<CircleCollider2D>().enabled = true;

        m_pencilTip.transform.position = m_player.transform.position + m_playerOffset;
        _positions = new List<Vector3>();
        _positions.Add(m_pencilTip.transform.position);

        m_lineRenderer.positionCount = 1;
        m_lineRenderer.SetPosition(0, m_pencilTip.transform.position);

        _target = m_pencilTip.transform.position + m_testMoves[_currentPointIndex];

    }

    void Update() {

        if (_currentPointIndex == m_testMoves.Count) {

            return;
        
        }

        m_pencilTip.transform.position = Vector3.MoveTowards(m_pencilTip.transform.position, _target, m_moveSpeed * Time.deltaTime);

        AddPointToLineRenderer(m_pencilTip.transform.position);

        if (m_pencilTip.transform.position == _target) {
            
            _currentPointIndex += 1;

            if (m_testMoves.Count > _currentPointIndex) {

                _target = m_pencilTip.transform.position + m_testMoves[_currentPointIndex];

            }

        }

    }

    void AddPointToLineRenderer(Vector3 point) {

        m_lineRenderer.positionCount += 1;
        m_lineRenderer.SetPosition(m_lineRenderer.positionCount - 1, point);

    }

}
