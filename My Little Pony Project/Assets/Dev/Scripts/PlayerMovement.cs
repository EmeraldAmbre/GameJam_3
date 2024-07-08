using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private GameObject m_player;

    [SerializeField] private float m_speed = 2f;
    [SerializeField] private float m_acceleration = 0.1f;
    [SerializeField] private float m_jumpForce = 5f;

    [SerializeField] private Rigidbody2D m_rigidbody;

    void Start()
    {
        if (m_rigidbody == null) m_rigidbody = m_player.GetComponent<Rigidbody2D>();
    }

    void Update() {

        m_speed += m_acceleration * Time.deltaTime;

        m_rigidbody.velocity = new Vector2(m_speed, m_rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(m_rigidbody.velocity.y) < 0.01f) // Assurez-vous que le personnage est sur le sol
        {
            m_rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse);
        }
    }
}
