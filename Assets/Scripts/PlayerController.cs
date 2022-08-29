using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float hmove;
    float vmove;
    bool isGrounded;
    [SerializeField] bool isFaceRight;
    [SerializeField] float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
    void Flip()
    {
        spriteRenderer.flipX = isFaceRight;
    }
    // Update is called once per frame, good for user input
    void Update()
    {
        hmove = Input.GetAxis("Horizontal");
        vmove = Input.GetAxis("Vertical");
        Debug.Log(hmove + " " + vmove);

        // Sets the character to face right or left
        if (Input.GetAxis("Horizontal") > 0)
        {
            isFaceRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            isFaceRight = false;
        }
        // --------------- CONTROLS ------------------
        // Jump
        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
        {
            rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            isGrounded = false;
        }
    Flip();
    }
    // Called potentially multiple times, good for physics updates
    void FixedUpdate()
    {
        //TODO add checks to update player isGrounded variable
        rigid.velocity = new Vector2(hmove * speed, vmove * speed);
    }
    void Jump()
    {
        rigid.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}