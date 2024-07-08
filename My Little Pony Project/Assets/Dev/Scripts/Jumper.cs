using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private float m_jumpForce = 5f;

    [SerializeField] private Rigidbody2D m_rigidbody;
    [SerializeField] private LayerMask jumpLayer;

    void OnCollisionEnter2D(Collision2D collision) {

        if (((1 << collision.gameObject.layer) & jumpLayer) != 0)
        {
            Jump();
        }
    }

    private void Jump() {

        m_rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse);

    }

}
