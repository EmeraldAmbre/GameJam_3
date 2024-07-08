using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerMovement : MonoBehaviour {

    [SerializeField] private GameObject m_pencilTip;
    [SerializeField] private GameObject m_direction;

    [SerializeField] private float m_rotationSpeed = 100f;
    [SerializeField] private float m_moveSpeed = 5f;

    [SerializeField] private LineRenderer m_lineRenderer;

    [SerializeField] private List<Vector3> m_positions;
    [SerializeField] private bool isMoving = false;

    void Start() {

        m_positions = new List<Vector3>();
        m_positions.Add(m_pencilTip.transform.position);

        m_lineRenderer.positionCount = 1;
        m_lineRenderer.SetPosition(0, m_pencilTip.transform.position);

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            isMoving = !isMoving;

            if (!isMoving) { m_positions.Add(m_pencilTip.transform.position); }

        }

        if (isMoving) { MovePointer(); }

        else {
            m_direction.transform.RotateAround(m_pencilTip.transform.position, Vector3.forward, m_rotationSpeed * Time.deltaTime);
        }

        Vector3 currentPosition = m_pencilTip.transform.position;

        if (m_positions.Count == 0 || Vector3.Distance(m_positions[m_positions.Count - 1], currentPosition) > 0.1f)
        {
            m_positions.Add(currentPosition);
            m_lineRenderer.positionCount = m_positions.Count;
            m_lineRenderer.SetPositions(m_positions.ToArray());
        }

    }

    void MovePointer() {
        Vector3 direction = (m_direction.transform.position - m_pencilTip.transform.position).normalized;
        m_pencilTip.transform.position += direction * m_moveSpeed * Time.deltaTime;
        m_direction.transform.position += direction * m_moveSpeed * Time.deltaTime;
    }

}
