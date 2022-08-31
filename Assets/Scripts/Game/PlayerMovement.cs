using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public GameObject shopMenu;
    public GameObject invonteryMenu;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _moveDirection = Vector3.zero;
        _moveDirection.x =  Input.GetAxis("Horizontal");
        _moveDirection.y = Input.GetAxis("Vertical");

        UpdateAnimation();

        if(Input.GetKeyDown(KeyCode.I) && !shopMenu.activeInHierarchy)
        {
            if (invonteryMenu.activeInHierarchy)
            {
                invonteryMenu.SetActive(false);
            }
            else
                invonteryMenu.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateAnimation()
    {
        if (_moveDirection != Vector2.zero)
        {
            _animator.SetFloat("moveX", _moveDirection.x);
            _animator.SetFloat("moveY", _moveDirection.y);
            _animator.SetBool("moving", true);
        }
        else
        {
            _animator.SetBool("moving", false);
        }
    }
}
