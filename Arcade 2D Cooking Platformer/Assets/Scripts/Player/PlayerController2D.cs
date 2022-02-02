
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private float _moveHorizontal; 
    [SerializeField] public float _moveSpeed; 

    [SerializeField] private float _jumpHeight; 
    [SerializeField] private bool isJumping;

    private Rigidbody2D _rigidbody2D;

    
    private void Awake() 
    { 
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();

        //Jump
        //Check if jump is occurring in Update()
        if (isJumping && Mathf.Abs(_rigidbody2D.velocity.y) < 0.001f)
        {
            isJumping = false;
            Jump();
        }
    }

    private void Inputs()
    {
        //Move the player left and right
        _moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void Move()
    {
        //Move the player
        _rigidbody2D.velocity = new Vector2(_moveHorizontal * _moveSpeed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        //Set up the vertical velocity
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);

        //Modify the velocity with force
        _rigidbody2D.AddForce(Vector2.up * _jumpHeight * 2, ForceMode2D.Impulse);

    }

    //double jump

    //flip
}
