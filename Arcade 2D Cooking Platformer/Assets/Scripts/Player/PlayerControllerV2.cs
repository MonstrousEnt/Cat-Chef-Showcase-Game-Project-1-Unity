
using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer; // The layer of the ground. This is use for collision checks.
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

    //wall jumping
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    public float checkRadius;

    [Header("Collision")]
    [SerializeField] private bool _onGround = false; //Determines if player is on ground using raycast
    [SerializeField] private bool isCeiling; //Determines if player is hitting the celling using raycast
    [SerializeField] private bool wasOnGround; //For checking if player is currently landing
    [SerializeField] private float _groundLength; //Length of the raycast for ground check
    [SerializeField] private float ceilingLength; //Length of the raycast for celling check
    [SerializeField] private Vector3 _colliderOffset; //Offset of raycast from the center of the player for FEET
    [SerializeField] private Vector3 _colliderOffset2; //Offset of raycast from the center of the player for HEAD



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
        //Boolean for landing set to the on ground raycasted value (jumping)
        wasOnGround = _onGround;
        //Ground check based on the raycast gizmos from the player location(collider offsets) (Jumping)
        _onGround = Physics2D.Raycast(transform.position + _colliderOffset, Vector2.down, _groundLength, _groundLayer)
            || Physics2D.Raycast(transform.position - _colliderOffset, Vector2.down, _groundLength, _groundLayer);

        Inputs();
        Jump();

    }

    private void FixedUpdate()
    {
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

        //-----wall jump check------
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, _groundLayer);

        if (isTouchingFront && !_onGround && _moveHorizontal != 0)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isClinging", true);
            wallSliding = true;

        }
        else
        {
            _animator.SetBool("isClinging", false);
            wallSliding = false;
        }

        //--wall sliding--
        if (wallSliding)
        {
            _animator.SetBool("isClinging", true);
            _extraJumps = extraJumpsAmount;
            //velocity for y is set between wall sliding speed and max value 
            _rigidbody2D.velocity = new Vector2(0, 0.4f);
        }

        if (Input.GetButtonDown("Jump") && wallSliding)
        {
            Flip();
            wallJumping = true;
            Invoke("SetWallJumpingFalse", wallJumpTime);
        }
        if (wallJumping)
        {
            _animator.SetBool("isClinging", false);
            _extraJumps = extraJumpsAmount;
            _rigidbody2D.velocity = new Vector2(xWallForce * -_moveHorizontal, yWallForce);
        }
        //--end wall sliding--//--wall sliding--
        if (wallSliding)
        {
            _animator.SetBool("isClinging", true);
            _extraJumps = extraJumpsAmount;
            //velocity for y is set between wall sliding speed and max value 
            _rigidbody2D.velocity = new Vector2(0, 0.4f);
        }

        if (Input.GetButtonDown("Jump") && wallSliding)
        {
            Flip();
            wallJumping = true;
            Invoke("SetWallJumpingFalse", wallJumpTime);
        }
        if (wallJumping)
        {
            _animator.SetBool("isClinging", false);
            _extraJumps = extraJumpsAmount;
            _rigidbody2D.velocity = new Vector2(xWallForce * -_moveHorizontal, yWallForce);
        }
        //--end wall sliding--

        //-----end wall jumping------

    }

    private void Jump()
    {
        if (_onGround == true)
        {
            _animator.SetBool("isJumping", false);
            _extraJumps = extraJumpsAmount;
        }


        //Jump
        //jump in air with extra jumps aka double jumps
        if (Input.GetButtonDown("Jump") && _extraJumps > 0)
        {
            //Modify the velocity with force
            _rigidbody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidbody2D.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
            _extraJumps--;
            _animator.SetBool("isJumping", true);

        }
        //jump from ground with no extra jumps, prevents infinite jumps
        else if (Input.GetButtonDown("Jump") && _extraJumps == 0 && _onGround)
        {
            //Modify the velocity with force
            _rigidbody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidbody2D.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
            _animator.SetBool("isJumping", true);

        }

        _animator.SetFloat("verticalvelocity", Mathf.Abs(_rigidbody2D.velocity.y));




    }


    //double jump

    //flip
    private void Flip()
    {
        if (!Mathf.Approximately(0, _moveHorizontal))
            transform.rotation = -_moveHorizontal > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }

    private void SetWallJumpingFalse()
    {
        wallJumping = false;
    }

    private void OnDrawGizmos()
    {
        //ground check
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + _colliderOffset, transform.position + _colliderOffset + Vector3.down * _groundLength);
        Gizmos.DrawLine(transform.position - _colliderOffset, transform.position - _colliderOffset + Vector3.down * _groundLength);

        //celling check
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + _colliderOffset2, transform.position + _colliderOffset2 + Vector3.up * ceilingLength);
        Gizmos.DrawLine(transform.position - _colliderOffset2, transform.position - _colliderOffset2 + Vector3.up * ceilingLength);
    }
}
