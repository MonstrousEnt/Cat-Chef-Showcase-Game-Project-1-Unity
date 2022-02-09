
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

   [SerializeField] private PauseMneu pauseMneu;


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
        Inputs();
        Jump();

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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMneu.gameObject.activeSelf)
            {
                pauseMneu.activeMenu(true);
                SettingManager.instance.ActivePause(true, 0f);
            }
            else
            {
                pauseMneu.activeMenu(false);
                SettingManager.instance.ActivePause(false, 1f);
            }
        }
    }

    private void Move()
    {
        //Move the player
        _rigidbody2D.velocity = new Vector2(_moveHorizontal * _moveSpeed, _rigidbody2D.velocity.y);

        _animator.SetFloat("movespeed", Mathf.Abs(_moveHorizontal));

        //-----wall jump check------
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if (isTouchingFront && !isGrounded && _moveHorizontal != 0)
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
        
        if (isGrounded == true)
        {
            _animator.SetBool("isJumping", false);
            _extraJumps = extraJumpsAmount;
        }
        

        //Jump
        //jump in air with extra jumps aka double jumps
        if (Input.GetButtonDown("Jump") && _extraJumps > 0)
        {                      

            FindObjectOfType<AudioManager>().playAudio("meow_jump");

            //Modify the velocity with force
            _rigidbody2D.velocity = Vector2.up * _jumpHeight;
            //_rigidbody2D.AddForce(new Vector2(0, _jumpHeight), ForceMode2D.Impulse);
            _extraJumps--;
            _animator.SetBool("isJumping", true);

        }
        //jump from ground with no extra jumps, prevents infinite jumps
        else if (Input.GetButtonDown("Jump") && _extraJumps == 0 && isGrounded)
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
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
