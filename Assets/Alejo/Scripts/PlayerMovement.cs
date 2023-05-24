using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Animations;
using Lean;
using Lean.Touch;

public class PlayerMovement : MonoBehaviour {
    //[SerializeField] private Vector2 jumpForce = new Vector2(0, 5);
    //[SerializeField] private bool isGrounded = false;
    //[SerializeField] private Animator playerAnim;
    //private bool isJumping = false;
    [Header("Projectile Settings")]
    [SerializeField] ProjectileBehaviour projectilePrefab;
    [SerializeField] Transform projectileSpawn;
    [SerializeField] float projectileCooldown;
    [SerializeField] private bool isAvailable;
    [Header("Move Settings")]
    [SerializeField] Vector3 upPos = new Vector3(-4f, -2.25f, 0f);
    [SerializeField] Vector3 downPos = new Vector3(-5f, -3.8f, 0f);

    private void Awake() {
        //playerAnim = GetComponent<Animator>();
        isAvailable = true;
    }
    void Update() {
        Actions();
    }

    /*private void JumpInput()
    {
        if (!Input.GetButtonDown("Jump") || !isGrounded) return;
        m_Rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        // Activa la variable booleana de salto
        isJumping = true;
        playerAnim.SetBool("isJumping", true);
    }*/

    private void Actions() {
        /*if (Input.GetButtonDown("Fire1") && isAvailable == true)
        {
            Instantiate(projectilePrefab, projectileSpawn.position, transform.rotation);
            isAvailable = false;
            StartCoroutine(StartCooldown());
            Debug.Log("Ataca");
        }*/
        if (Input.GetButtonDown("Fire2")) {
            Debug.Log("Esquiva");
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            this.transform.position = upPos;
            Debug.Log("Move");
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            this.transform.position = downPos;
            Debug.Log("Move");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            // Desactiva la variable booleana de salto
            isJumping = false;
            playerAnim.SetBool("isJumping", false);
        }
    }*/

    public IEnumerator StartCooldown() {
        yield return new WaitForSeconds(projectileCooldown);
        isAvailable = true;
    }

    public void Atack() {

        Instantiate(projectilePrefab, projectileSpawn.position, transform.rotation);
        isAvailable = false;
        StartCoroutine(StartCooldown());
        Debug.Log("Ataca");

    }

    public void MoveUP(LeanFinger finger) {

        if (finger.SwipeScreenDelta.normalized.y > 0) {
            this.transform.position = upPos;
            Debug.Log("Move UP" + finger.SwipeScreenDelta.normalized);
        }
        else {
            this.transform.position = downPos;
            Debug.Log("Move Down");
        }
    }
}


