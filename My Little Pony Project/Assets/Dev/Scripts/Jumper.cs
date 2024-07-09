using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_pointer;
    [SerializeField] private GameObject m_testPointer;
    [SerializeField] private Rigidbody2D m_rigidbody;

    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private float m_jumpForce = 5f;

    [SerializeField] private float m_slowMotionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;

    public bool _test;

    private void Start() {

        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
        _test = false;

    }

    private void Update() {

        // bool movementsAreSimilar = CompareMovements(scriptA.positionsA, scriptB.positionsB);

    }

    private void FixedUpdate() {

        if (_test) {

            Jump();
            _test = false;
        
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (((1 << collision.gameObject.layer) & jumpLayer) != 0) {

            // StartSlowMotion();

            if (_test) {

                Jump();
                // StopSlowMotion();

            }
        }
    }

    private void Jump() {

        m_rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse);

    }

    /*
     * Slow motions techniques
     * 
     * private void StartSlowMotion() {

        Time.timeScale = m_slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * m_slowMotionTimeScale;

    }

    private void StopSlowMotion() {

        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;

    }
     */

}
