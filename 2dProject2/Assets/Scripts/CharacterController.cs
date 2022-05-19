using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpForce = 250.0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _anim;

    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //caching rigidBody
        _anim = GetComponent<Animator>(); //caching animator
        //started = true;
        grounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            if (started && grounded)
            {
                //jump
                _anim.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _anim.SetBool("GameStarted", true);
                started = true;
            }
        }
        _anim.SetBool("Grounded", grounded);

    }
    private void FixedUpdate()
    {
        if (started)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }
        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
