using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class palyercontrol1 : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public GameObject pos;
    public GameObject shotpoint;
    public GameObject bullet123;
    public Transform Celcheck;
    public Transform grdcheck;
    public LayerMask groundobjects;
    public float checkRad;
    public int score;
    public Text Uscore;

    private Rigidbody2D rb;
    private bool facingright = true;
    private float movedirection;
    private bool isjumping = false;
    private bool isGrounded;

    public float health = 1f;
    public Slider healthSlider;
    public Vector3 originalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void shooting(){
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet123, shotpoint.transform.position, shotpoint.transform.rotation);
        }

    }
    void Update()
    {
        Inputdeal();
        Animation();
        shooting();

    }
    private void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(grdcheck.position, checkRad, groundobjects);
        move();

        
    }
    private void move()
    {
        rb.velocity = new Vector2(movedirection * movespeed, rb.velocity.y);
        if (isjumping==true&& isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpforce));

        }
        isjumping = false;

    }
    private void Inputdeal() {
        movedirection = Input.GetAxis("Horizontal");

        
        if (Input.GetButtonDown("Jump"))
        {
            isjumping = true;
        }

    }
    private void Flipcharacter() {

        facingright = !facingright;
        transform.Rotate(0f,180f,0f);
    }
    private void Animation() {
        if (movedirection > 0 && !facingright)
        {
            Flipcharacter();
        }
        else if (movedirection < 0 && facingright)
        {
            Flipcharacter();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet2"))
        {
            health -= 0.2f;
            Destroy(collision.gameObject);
            healthSlider.value = 1 - health;
            if(Mathf.Abs(health - 0)<=0.05f)
            {
                transform.position = originalPosition;
                health = 1f;
            }
        }
        
    }
    private void OOnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("scorezone"))
        {
            score++;
            Uscore.text = "Redscore"+score.ToString();
            

        }
    }
}
