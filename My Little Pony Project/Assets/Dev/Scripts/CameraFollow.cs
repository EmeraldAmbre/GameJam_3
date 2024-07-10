using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform m_player;
    [SerializeField] private Vector3 m_offset;

    void Update() {

        if (m_player != null) { transform.position = new Vector3(m_player.position.x, transform.position.y, transform.position.z) + m_offset; }

    }

}
