
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _moveHorizontal; 

    [SerializeField] public float _moveSpeed; 
    [SerializeField] private float _jumpHeight; 
    [SerializeField] private bool isJumping;

    //jumping
    [Header("Jumping")]

    private int _extraJumps;
    public int extraJumpsAmount;

    [SerializeField] private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //wall jumping
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;



    private void Awake() 
    { 
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _extraJumps = extraJumpsAmount;
    }

    private void Update()
    {
        if(isGrounded == true)
        {
            _extraJumps = extraJumpsAmount;
        }
        Inputs();

        //Jump
        //jump in air with extra jumps aka double jumps
        if (Input.GetButtonDown("Jump") && _extraJumps > 0)
        {
            //Modify the velocity with force
            _rigidbody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidbody2D.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
            _extraJumps--;

        }
        //jump from ground with no extra jumps, prevents infinite jumps
        else if (Input.GetButtonDown("Jump") && _extraJumps == 0 && isGrounded)
        {
            //Modify the velocity with force
            _rigidbody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidbody2D.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);

        }

        _animator.SetFloat("verticalvelocity", Mathf.Abs(_rigidbody2D.velocity.y));

       

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Move();            

        Flip();
    }


    private void Inputs()
    {
        //Move the player left and right
        _moveHorizontal = Input.GetAxisRaw("Horizontal");

       


    }

    private void Move()
    {
        //Move the player
        _rigidbody2D.velocity = new Vector2(_moveHorizontal * _moveSpeed, _rigidbody2D.velocity.y);

        _animator.SetFloat("movespeed", Mathf.Abs(_moveHorizontal));

        //wall jump check
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront && !isGrounded && _moveHorizontal != 0)
        {
            Debug.Log("wall sliding");
            _animator.SetBool("isClinging", true);
            wallSliding = true;

        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            _animator.SetBool("isClinging", false);
            _extraJumps = extraJumpsAmount;
            //velocity for y is set between wall sliding speed and max value 
            _rigidbody2D.velocity = new Vector2(0, 0);
        }

        if (Input.GetButtonDown("Jump") && wallSliding)
        {

            wallJumping = true;
            Invoke("SetWallJumpingFalse", wallJumpTime);
        }
        if (wallJumping)
        {
            _animator.SetBool("isClinging", false);
            _extraJumps = extraJumpsAmount;
            _rigidbody2D.velocity = new Vector2(xWallForce * -_moveHorizontal, yWallForce);
        }

    }

    private void Jump()
    {
                 
       
    }


    //double jump

    //flip
    private void Flip()
    {
        if (!Mathf.Approximately(0, _moveHorizontal))
            transform.rotation = _moveHorizontal > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }

    private void SetWallJumpingFalse()
    {
        wallJumping = false;
    }
}
