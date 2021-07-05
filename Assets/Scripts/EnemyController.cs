using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float xMaxDistance;  // set to 10 for ground creatures and 1.2 / 1.7 for platform creatures

    Animator anim;

    int dir; // 0, 1, or -1
    float startXPosition;
    float speed;

    float scaleFactor;

    void Start()
    {
        anim = GetComponent<Animator>();

        dir = -1;
        startXPosition = transform.position.x;
        speed = 5f;
        scaleFactor = 0.5f;
    }

    void Update()
    {
        if (Mathf.Abs(startXPosition - transform.position.x) >= xMaxDistance)
        {
            dir = -dir;
        }
        
        transform.Translate(dir * speed * Time.deltaTime, 0, 0);
        if (dir < 0)
        {
            transform.localScale = new Vector2(-scaleFactor, scaleFactor);
            // play animation
            anim.SetBool("isWalking", true);
        }
        else if (dir > 0)
        {
            transform.localScale = new Vector2(scaleFactor, scaleFactor);
            // player walk right animation
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

}
