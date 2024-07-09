using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerMovement : MonoBehaviour {

    [SerializeField] private GameObject m_pencilTip;
    [SerializeField] private GameObject m_direction;
    [SerializeField] private GameObject m_player;

    [SerializeField] private float m_rotationSpeed = 100f;
    [SerializeField] private float m_moveSpeed = 5f;
    [SerializeField] private bool isMoving = false;

    [SerializeField] private LineRenderer m_lineRenderer;
    [SerializeField] private List<Vector3> m_points;

    public List<Vector3> _positions;
    private Vector3 _currentPosition;
    private float _angle;

    [SerializeField] Vector3 m_pointerOffset = new(0, 0.75f, 0);
    [SerializeField] Vector3 m_playerOffset = new(0, 3.75f, 0);

    void Start() {

        m_pencilTip.transform.position = m_player.transform.position + m_playerOffset;
        m_direction.transform.position = m_player.transform.position + m_playerOffset + m_pointerOffset;

        isMoving = false;

        _positions = new List<Vector3>();
        _positions.Add(m_pencilTip.transform.position);

        _currentPosition = m_pencilTip.transform.position;

        m_lineRenderer.positionCount = 1;
        m_lineRenderer.SetPosition(0, m_pencilTip.transform.position);

        m_points.Add(_currentPosition);

    }

    void Update() {

        _currentPosition = m_pencilTip.transform.position;

        if (Input.GetKeyDown(KeyCode.Space)) {

            isMoving = !isMoving;

            if (!isMoving) {

                m_points.Add(_currentPosition);
                Vector3 movement = _currentPosition + m_points[m_points.LastIndexOf(_currentPosition)-1];

            }

        }

        if (isMoving) { MovePointer(); }

        else { m_direction.transform.RotateAround(m_pencilTip.transform.position, Vector3.forward, m_rotationSpeed * Time.deltaTime); }

        if (_positions.Count == 0 || Vector3.Distance(_positions[_positions.Count - 1], _currentPosition) > 0.1f) {
            _positions.Add(_currentPosition);
            m_lineRenderer.positionCount = _positions.Count;
            m_lineRenderer.SetPositions(_positions.ToArray());
        }

    }

    private void MovePointer() {

        Vector3 direction = (m_direction.transform.position - m_pencilTip.transform.position).normalized;
        m_pencilTip.transform.position += direction * m_moveSpeed * Time.deltaTime;
        m_direction.transform.position += direction * m_moveSpeed * Time.deltaTime;

    }

    private float CalculateAngle(float x, float y) {

        float angle = 0f;

        angle = x / Mathf.Sqrt((x*x) + (y*y));
        angle = Mathf.Acos(angle);
        angle = (angle * 180) / Mathf.PI; // Convert the angle in degrees

        return angle;

    }

}
