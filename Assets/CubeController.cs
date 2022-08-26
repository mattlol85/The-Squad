using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] float hmove;
    [SerializeField] float vmove;
    [SerializeField] float speed;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
     if(rigid == null){
        rigid = GetComponent<Rigidbody2D>();
     }
    }

    // Update is called once per frame, good for user imput
    void Update()
    {
     hmove = Input.GetAxis("Horizontal");
     vmove = Input.GetAxis("Vertical");   
    }
    // Called potentially multiple times, good for physics updates
    void FixedUpdate ()
    {
     rigid.velocity = new Vector2(hmove*speed,vmove*speed);   
    }
}
