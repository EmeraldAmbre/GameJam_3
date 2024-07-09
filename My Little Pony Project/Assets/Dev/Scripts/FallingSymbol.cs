using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSymbol : MonoBehaviour
{
    [SerializeField] private float m_fallSpeed = 0.05f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = m_fallSpeed;
        }
    }
}
