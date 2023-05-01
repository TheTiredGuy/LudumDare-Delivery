using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [SerializeField] private float _speed = 5f;
    private Vector2 _moveInput;
    //[SerializeField] private float _smoothedTime = 0.1f;
    //[SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _jumpPower = 10f;

    [SerializeField] private Vector2 _groundedSize;
    [SerializeField] private float _groundedDistance;
    [SerializeField] private Vector2 _sideCollSize;
    [SerializeField] private float _sideCollDistance;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private LayerMask _playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        anim.SetFloat("Move", Mathf.Abs(_moveInput.x));
        if (rb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void AirLogic(Vector2 velocity)
    {

    }

    private bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, _groundedSize, 0, -transform.up, _groundedDistance, _groundLayer))
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
        Gizmos.DrawWireCube(transform.position - transform.up * _groundedDistance, _groundedSize);
        Gizmos.DrawWireCube(transform.position - transform.up * _sideCollDistance, _sideCollSize);
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

    public void OnQuit(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Title");
    }

}
