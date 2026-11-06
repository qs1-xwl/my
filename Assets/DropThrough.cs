using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThrough : MonoBehaviour
{
    private Collider2D boardCollider;
    private float dropTimer;

    void Start()
    {
        boardCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && dropTimer <= 0)
        {
            if (boardCollider != null)
            {
                boardCollider.enabled = false;
                dropTimer = 0.4f;
            }
        }

        if (dropTimer > 0)
        {
            dropTimer -= Time.deltaTime;
            if (dropTimer <= 0)
            {
                if (boardCollider != null)
                {
                    boardCollider.enabled = true;
                }
            }
        }
    }
}