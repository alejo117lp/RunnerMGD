using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForce = new Vector2(0,5);
    private Rigidbody2D m_Rigidbody;
    [SerializeField] private bool isGrounded = false;
    
    
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        PlayerInputs();
    }

    private void PlayerInputs()
    {
        if (!Input.GetButtonDown("Jump") || !isGrounded) return;
        m_Rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
