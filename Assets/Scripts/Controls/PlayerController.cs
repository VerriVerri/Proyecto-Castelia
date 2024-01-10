using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject animatorObj;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    bool isGrounded;
    bool isJumping;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Jump
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (!isGrounded)
        {
            //Player is airborne
            animatorObj.GetComponent<Animator>().Play("jump");
        }

        if (horizontalInput == 0)
        {
            // Player is idle
            Debug.Log("standing still");

            if (isGrounded)
            {
                animatorObj.GetComponent<Animator>().Play("idle");
            }
        }

        if (horizontalInput < 0)
        {
            // Player is moving left
            Debug.Log("Moving left");
            transform.localScale = new Vector3(-1f, 1f, 1f);

            if (isGrounded)
            {
                animatorObj.GetComponent<Animator>().Play("walk");
            }
        }
        else if (horizontalInput > 0)
        {
            // Player is moving right
            Debug.Log("Moving right");
            transform.localScale = new Vector3(1f, 1f, 1f);

            if (isGrounded)
            {
                animatorObj.GetComponent<Animator>().Play("walk");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
