using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {

    // Player variables
    [SerializeField] private GameObject m_player;
    [SerializeField] private Rigidbody2D m_rigidbody;
    private bool _canJump;

    // Clicks variables
    [SerializeField] private float clickDuration = 5f; // Durée pendant laquelle les clics sont enregistrés
    [SerializeField] private float tolerance = 0.2f;
    private float timer;
    private List<Vector3> clickPositions = new List<Vector3>();

    // Trigger element
    [SerializeField] private LayerMask jumpLayer;
    [SerializeField] private float m_jumpForce = 5f;

    // Slow motion variables
    [SerializeField] private float m_slowMotionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;

    // Symbols variables
    [SerializeField] private List<GameObject> _symbols;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private int _symbolLayer;
    private LineRenderer _symbolLineRenderer;

    // Symbols spawner
    [SerializeField] private float m_spawnRate = 2f;
    private float nextSpawn = 0f;

    private void Start() {

        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
        timer = 0;

    }

    void Update() {

        // Vérifie si le temps de clic est écoulé
        if (timer > 0) {

            timer -= Time.deltaTime;

            // Vérifie si le bouton gauche de la souris est cliqué
            if (Input.GetMouseButtonDown(0)) {

                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                clickPositions.Add(worldPosition);
            }
        }

        else {

            int index = Random.Range(0, _symbols.Count);
            GameObject symbol = Instantiate(_symbols[index], _spawnPosition, Quaternion.identity);
            _symbolLineRenderer = symbol.GetComponentInChildren<LineRenderer>();
            Destroy(symbol, clickDuration);
            ResetClicking();

        }

    }

    public void ResetClicking() {

        timer = clickDuration;
        clickPositions.Clear();

    }

    public bool Verify() {

        if (clickPositions.Count != _symbolLineRenderer.positionCount) return false;

        else {

            for (int i = 0; i < _symbolLineRenderer.positionCount; i++) {
                if (Vector3.Distance(_symbolLineRenderer.GetPosition(i), clickPositions[i]) > tolerance) { return false; }
            }

        }

        return true;

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (((1 << collision.gameObject.layer) & jumpLayer) != 0) {

            if (Verify()) { Jump(); }

        }
    }

    private void Jump() { m_rigidbody.AddForce(new Vector2(0, m_jumpForce), ForceMode2D.Impulse); }

    /*
     * Slow motions techniques
     * 
     * private void StartSlowMotion() {
     *  
     *  Time.timeScale = m_slowMotionTimeScale;
     *  Time.fixedDeltaTime = startFixedDeltaTime * m_slowMotionTimeScale;
     *
     * }
     *
     * private void StopSlowMotion() {
     *
     *  Time.timeScale = startTimeScale;
     *  Time.fixedDeltaTime = startFixedDeltaTime;
     *
     * }
     * 
     */

}
