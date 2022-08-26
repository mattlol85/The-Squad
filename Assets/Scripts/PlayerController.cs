using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float hmove;
    [SerializeField] float vmove;
    [SerializeField] float speed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
     if(rigid == null){
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
     }
    }

    // Update is called once per frame, good for user input
    void Update()
    {
     hmove = Input.GetAxis("Horizontal");
     vmove = Input.GetAxis("Vertical");

     Debug.Log(rigid.velocity);   
    }
    // Called potentially multiple times, good for physics updates
    void FixedUpdate ()
    {
     rigid.velocity = new Vector2(hmove*speed,vmove*speed);
    // Flip sprite depending on direction
    if(rigid.velocity.x > 0){
        spriteRenderer.flipX = true;
    }else{
        spriteRenderer.flipX = false;
    }

    }
}