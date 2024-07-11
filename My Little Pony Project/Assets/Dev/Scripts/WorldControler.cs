using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControler : MonoBehaviour
{
    [SerializeField] float m_moveSpeed = 5f;

    private void Update()
    {
        transform.position += Vector3.left * m_moveSpeed * Time.deltaTime;

        if (transform.position.x <= -56.2f) { transform.Translate(new Vector3(108.6f, 0, 0)); }
    }
}
