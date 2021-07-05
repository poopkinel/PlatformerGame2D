using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    Collider col;

    float x;
    float speed;
    float walkSpeed;
    float runSpeed;
    float jumpThrust;

    bool isGrounded;
    bool isSliding;
    bool isDead;

    float playerScale;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider>();

        walkSpeed = 5f;
        runSpeed = 10f;
        speed = walkSpeed;

        jumpThrust = 400f;
        isGrounded = true;
        isSliding = false;
        isDead = false;

        playerScale = 0.2f;
    }

    void Update()
    {

        if (!isDead)
        {
            x = Input.GetAxis("Horizontal");
            transform.Translate(x * Time.deltaTime * speed, 0, 0);


            if (x == 0)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isRunning", false);
            }
            else if (x > 0)
            {
                if (Input.GetKey(KeyCode.Space) && isGrounded)
                {
                    speed = runSpeed;
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetTrigger("slide");
                    }
                    else
                    {
                        anim.SetBool("isRunning", true);
                        anim.SetBool("isWalking", false);
                    }
                }
                else if (isGrounded)
                {
                    speed = walkSpeed;
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isWalking", true);
                }
                transform.localScale = new Vector2(playerScale, playerScale);
            }
            else if (x < 0)
            {
                if (Input.GetKey(KeyCode.Space) && isGrounded)
                {
                    speed = runSpeed;
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        anim.SetTrigger("slide");
                    }
                    else
                    {
                        anim.SetBool("isRunning", true);
                        anim.SetBool("isWalking", false);
                    }
                }
                else if (isGrounded)
                {
                    speed = walkSpeed;
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isWalking", true);
                }
                transform.localScale = new Vector2(-playerScale, playerScale);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isGrounded)
                {
                    rb.AddForce(new Vector2(0f, jumpThrust));
                    anim.SetTrigger("jump");
                    isGrounded = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "Ground")
            {
                anim.Play("IdleAnimation");  // *
                isGrounded = true;
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                anim.SetTrigger("dead");
                isDead = true;
                rb.isKinematic = true;
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(0f, 0f);
                Destroy(gameObject, 2);

                StartCoroutine(DelayedSceneChange(1f, "Game Over"));
            }
        }
    }

    IEnumerator DelayedSceneChange(float delay, string sceneName)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(sceneName);
    }

}
