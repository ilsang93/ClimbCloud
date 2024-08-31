using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkForce = 30f;
    [SerializeField] private float maxWalkSpeed = 2f;
    [SerializeField] private float jumpForce = 680f;
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }

        float speedX = Mathf.Abs(rb.velocity.x);
        if (speedX < maxWalkSpeed)
        {
            rb.AddForce(key * walkForce * transform.right);
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (transform.position.y <= -10f) {
            SceneManager.LoadScene("GameScene");
        }

        // 플레이어의 속도에 맞춰 애니메이션 속도를 바꿔준다.
        animator.speed = speedX / 2f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("flag"))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
