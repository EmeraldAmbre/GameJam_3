using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform m_player;
    [SerializeField] private Vector3 m_offset;

    void Update() {
        if (m_player != null) { transform.position = m_player.position + m_offset; }
    }

}
