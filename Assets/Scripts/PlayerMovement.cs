using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D _rb;

    private float _moveDirectionHorizontal;
    private float _moveDirectionVertical;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        _moveDirectionHorizontal =  Input.GetAxis("Horizontal");
        _moveDirectionVertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_moveDirectionHorizontal, _moveDirectionVertical) * moveSpeed;
    }
}
