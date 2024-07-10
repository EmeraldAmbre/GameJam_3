using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneDrawer : MonoBehaviour
{
    private int m_nextIndexInDraw;
    [SerializeField] private int m_nbOfindexToSucceed;

    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Rigidbody2D _rigidbody;

    internal void UpdateDraw(int _index)
    {
        if(_index == m_nextIndexInDraw)
        {
            m_nextIndexInDraw++;
            if (m_nextIndexInDraw == m_nbOfindexToSucceed) ValidateDraw();
        }
        else
        {
            FailDraw();
        }
    }

    private void FailDraw()
    {
        Debug.Log("FailDraw");
    }

    private void ValidateDraw()
    {
        Jump();
        Debug.Log("ValidateDraw");
    }

    private void Jump() { _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse); }
}
