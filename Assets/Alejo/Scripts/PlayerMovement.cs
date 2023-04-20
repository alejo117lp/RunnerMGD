using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 jumpForce = new Vector2(0, 5);
    private Rigidbody2D m_Rigidbody;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Animator playerAnim;
    private bool isJumping = false;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
    void Update()
    {
        JumpInput();
        Attack();
    }

    private void JumpInput()
    {
        if (!Input.GetButtonDown("Jump") || !isGrounded) return;
        m_Rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        // Activa la variable booleana de salto
        isJumping = true;
        playerAnim.SetBool("isJumping", true);
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ataca");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            // Desactiva la variable booleana de salto
            isJumping = false;
            playerAnim.SetBool("isJumping", false);
        }
    }
}
