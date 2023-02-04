using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyercontrol2 : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public GameObject pos;
    public Transform Celcheck;
    public Transform grdcheck;
    public LayerMask groundobjects;
    public float checkRad;
    public GameObject shotpoint;
    public GameObject bullet123;

    private Rigidbody2D rb;
    private bool facingright = true;
    private float movedirection;
    private bool isjumping = false;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void shooting()
    {
        if (Input.GetKeyDown(KeyCode.L))
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
        movedirection = Input.GetAxis("Horizontal2");

        
        if (Input.GetButtonDown("Jump2"))
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


}
