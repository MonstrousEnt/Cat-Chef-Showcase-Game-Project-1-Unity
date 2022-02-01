
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    [SerializeField] public float MovementSpeed = 1f;
    [SerializeField] public float JumpForce = 1f;

    private Rigidbody2D _rigidbody2d;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //horizontal movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * MovementSpeed;

        //flip code 
        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        //jump code
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody2d.velocity.y) < 0.001f)
        {
            _rigidbody2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
