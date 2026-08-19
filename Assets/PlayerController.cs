using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }

    void Update()
    {
        moveInput = Keyboard.current.aKey.isPressed ? -1 :
             Keyboard.current.dKey.isPressed ? 1 : 0;

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-6.0f, 6.0f, 6.0f);
        }

       

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, 0);
    }

 

}