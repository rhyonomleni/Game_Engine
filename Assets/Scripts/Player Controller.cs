using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    bool isJump = true;
    bool isDead = false;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
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

        if (Input.GetKey(KeyCode.Space)){
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
