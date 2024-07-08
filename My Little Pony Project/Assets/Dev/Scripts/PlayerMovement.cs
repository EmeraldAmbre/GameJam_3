using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private GameObject m_player;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Accélération du mouvement au fur et à mesure du temps
        speed += acceleration * Time.deltaTime;

        // Appliquer le mouvement horizontal
        rb.velocity = new Vector2(speed, rb.velocity.y);

        // Vérifier si le bouton de saut est pressé (Espace par défaut)
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f) // Assurez-vous que le personnage est sur le sol
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
