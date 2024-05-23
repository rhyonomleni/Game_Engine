using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int jumpCount;
    [SerializeField] private int jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2( horizontalInput * speed, body.velocity.y);
        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(2, 2, 1);
        }else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-2, 2, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump(){
        if (grounded || jumpCount < 2)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            anim.SetTrigger("jump");
            grounded = false;
            jumpCount++;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpCount = 0;
        }
    }
}
