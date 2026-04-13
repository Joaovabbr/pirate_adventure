using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private AudioSource audio;
    public AudioClip coinSound;
    public AudioClip crashSound;
    
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;
    
    private bool isStunned = false;
    private float stunTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0)
            {
                isStunned = false;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStunned) 
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        if (Mathf.Abs(moveHorizontal) > Mathf.Abs(moveVertical))
        {
            if (moveHorizontal > 0) spriteRenderer.sprite = spriteRight;
            else if (moveHorizontal < 0) spriteRenderer.sprite = spriteLeft;
        }
        else if (Mathf.Abs(moveVertical) > Mathf.Abs(moveHorizontal))
        {
            if (moveVertical > 0) spriteRenderer.sprite = spriteUp;
            else if (moveVertical < 0) spriteRenderer.sprite = spriteDown;
        }
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coletável"))
        {
            audio.PlayOneShot(coinSound);
            GameController.Collect();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("obstacle"))
        {
            audio.PlayOneShot(crashSound);
            GameController.LoseLife();
            
            isStunned = true;
            stunTimer = 1.0f;
            
            Destroy(other.gameObject);
        }
    }
}
