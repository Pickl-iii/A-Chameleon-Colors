using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private Vector3 vehiclePosition = Vector3.zero;
    private Vector3 vehicleDirection = Vector3.zero;
    private Vector3 vehicleVelocity = Vector3.zero;

    private float spriteHeight;
    private float spriteWidth;


    // Start is called before the first frame update
    void Start()
    {
        vehiclePosition = transform.position;

        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        // Move Vehicle
        vehicleVelocity = vehicleDirection * (speed * Time.deltaTime);      // Calculate Velocity
        vehiclePosition += vehicleVelocity;                                 // Add Velocity to current Position


        // Wrap Vehicle
        Camera cam = Camera.main;
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        if ((vehiclePosition.y - spriteHeight) > height)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, -1 * (height + spriteHeight), vehiclePosition.z);
        }
        else if ((vehiclePosition.y + spriteHeight) < -1 * height)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, (height + spriteHeight), vehiclePosition.z);
        }

        if ((vehiclePosition.x - spriteWidth) > width)
        {
            vehiclePosition = new Vector3(-1 * (width + spriteWidth), vehiclePosition.y, vehiclePosition.z);
        }
        else if ((vehiclePosition.x + spriteWidth) < -1 * width)
        {
            vehiclePosition = new Vector3((width + spriteWidth), vehiclePosition.y, vehiclePosition.z);
        }



        transform.position = vehiclePosition;                               // Update Transform
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        vehicleDirection = context.ReadValue<Vector2>();

        if (vehicleDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, vehicleDirection);
        }

    }
}
