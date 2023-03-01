using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 12f;
    public float distanceToGround;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    private bool facingRight;
    private bool grounded;

    public Transform poz;

    public Transform getPozition()
    {
        return poz;
    }

    void Start()
    {
        //ініціалізація компонентів
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //вхідні дані про переміщення вліво-вправо
        horizontal = Input.GetAxis("Horizontal");

        //анімація ходьби
        anim.SetFloat("Move", Mathf.Abs(horizontal));

        //перевірка чи персонаж стоїть на землі
        CheckGround();

        //зміна напрямку персонажа
        if (horizontal > 0 && facingRight || horizontal < 0 && !facingRight)
            Flip();

        //анімація ударів
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Punch");
        if (Input.GetMouseButtonDown(1))
            anim.SetTrigger("Kick");

        //реалізація стрибку та його анімації
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
            Jump();

        //анімація приземлення після стрибку
        if (rb.velocity.y < 0)
            anim.SetBool("Jump", false);

        //переміщення персонажа вліво-вправо
        if (horizontal != 0)
            Move();
    }

    private void CheckGround()
    {
        grounded = Physics2D.Raycast(rb.position, Vector3.down, distanceToGround, groundMask);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
    }

    private void Move()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
        Vector3 position = rb.position;
        position.x = Mathf.Clamp(position.x, -5, 6);
        rb.position = position;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//public class PlayerController : MonoBehaviour
//{
//    Rigidbody2D rb;
//    Animator anim;
//    public float speed, jumpForse;
//    float moveInput;
//    public bool isGrounded = true;
//    bool jumpb, facingRight = true;
//    public Transform groundCheck;
//    public float checkRadius;
//    public LayerMask whatIsGround;
//    private int extraJumps;
//    public int extraJumpsValue;
//    public Transform poz; public Transform getPozition()
//    {
//        return poz;
//    }
//    void Start()
//    {
//        extraJumps = extraJumpsValue;
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//    }
//    void FixedUpdate()
//    {
//        playAnimation();
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); moveInput = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); if (facingRight == false && moveInput > 0)
//        {
//            Flip();
//        }
//        else if (facingRight == true && moveInput < 0)
//        {
//            Flip();
//        }
//    }
//    void playAnimation()
//    {
//        if (moveInput != 0)
//        {
//            anim.SetBool("Run", true);
//        }
//        else
//        {
//            anim.SetBool("Run", false);
//        }
//    }
//    void Flip()
//    {
//        facingRight = !facingRight;
//        Vector3 Scaler = transform.localScale;
//        Scaler.x *= -1;
//        transform.localScale = Scaler;
//    }
//    private void Update()
//    {
//        if (isGrounded == true)
//        {
//            extraJumps = extraJumpsValue;
//        }
//        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
//        {
//            rb.velocity = Vector2.up * jumpForse;
//            extraJumps--;
//        }
//        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
//        {
//            rb.velocity = Vector2.up * jumpForse;
//        }
//    }
//}