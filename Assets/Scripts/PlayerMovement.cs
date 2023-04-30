using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;


    [SerializeField] private float _speed = 5f;
    private Vector2 _moveInput;
    private Vector2 _smoothedMovement;
    private Vector2 _smoothedVelocity;
    [SerializeField] private float _smoothedTime = 0.1f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpPower = 10f;

    [SerializeField] private Vector2 _playerSize;
    [SerializeField] private float _groundedDistance;
    [SerializeField] private LayerMask _groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementLogic();

    }

    private void MovementLogic()
    {



        //_smoothedMovement = Vector2.SmoothDamp(_smoothedMovement, _moveInput, ref _smoothedVelocity, _smoothedTime);


        Vector2 velocity = new Vector2(_moveInput.x * _speed, rb.velocity.y);
        if (isGrounded())
        {
            velocity.y = -0.1f;
        }
        else
        {
            velocity.y = rb.velocity.y;
        }
        rb.velocity = new Vector2(_moveInput.x * _speed, rb.velocity.y);

    }

    private bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, _playerSize, 0, -transform.up, _groundedDistance, _groundLayer))
        {
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * _groundedDistance, _playerSize);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (isGrounded())
        {
            rb.AddForce(new Vector2(rb.velocity.y, _jumpPower));
        }
        
    }

}
