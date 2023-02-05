using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool hasPickup = false;

    public AudioSource audios;
    public AudioClip hurt;
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip getScore;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void shooting()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Instantiate(bullet123, shotpoint.transform.position, shotpoint.transform.rotation);
            audios.PlayOneShot(shoot);
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
            audios.PlayOneShot(jump);

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

    private void OnTriggerEnter2D(Collider2D aaa)
    {
        if (aaa.gameObject.CompareTag("Bullet2"))
        {
            health -= 0.2f;
            Destroy(aaa.gameObject);
            healthSlider.value = 1 - health;
            audios.PlayOneShot(hurt);
            if (Mathf.Abs(health - 0) <= 0.05f)
            {
                transform.position = originalPosition;
                health = 1f;
                healthSlider.value = 1 - health;
            }

        }
        else if (aaa.gameObject.CompareTag("scorezone"))
        {
            if (hasPickup == true)
            {
                score++;
                Uscore.text = "Bluescore" + score.ToString();
                audios.PlayOneShot(getScore);

                //UnityEngine.Debug.Log("s");
                Destroy(this.transform.GetChild(6).gameObject);
                hasPickup = false;
            }
        }

    }
}
