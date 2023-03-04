using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Vector2 movement;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;

        Vector2 adjustedMovement = movement * movementSpeed;

        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

        rbody.MovePosition(newPos);
    }

    void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
}
