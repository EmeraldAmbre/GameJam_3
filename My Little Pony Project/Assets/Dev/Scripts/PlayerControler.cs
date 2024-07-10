using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public bool canJump;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Rigidbody2D _rigidbody;
    
    void Update()
    {
        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Jump() { _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse); }

}
