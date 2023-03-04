using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    // Movement Variables =============
    [SerializeField] private float movementSpeed;
    private Vector2 movement;
    private Rigidbody2D rbody;

    // Spawning Variables =============
    private GameObject[] respawns = null;
    private SpriteRenderer sprite;

    // Background Variables ============
    [SerializeField] private GameObject background = null;
    private Color[] colors = null;
    private int currentColor;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("Player");
        sprite = transform.GetComponent<SpriteRenderer>();

        if (respawns.Length == 1)
        {
            transform.position = new Vector3(-5, 0, 1);
            sprite.color = Color.blue;
            background = GameObject.Find("Right Background");

            colors = new Color[3];
            colors[0] = Color.magenta;
            colors[1] = Color.cyan;
            colors[2] = Color.yellow;
        }
        else
        {
            transform.position = new Vector3(5, 0, 1);
            sprite.color = Color.red;
            background = GameObject.Find("Left Background");

            colors = new Color[3];
            colors[0] = Color.red;
            colors[1] = Color.blue;
            colors[2] = Color.green;
        }
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

    void OnCycleBackgroundLeft()
    {
        currentColor--;
        if (currentColor < 0) { currentColor = 2; }
        background.GetComponent<SpriteRenderer>().color = colors[currentColor];
    }

    void OnCycleBackgroundRight()
    {
        currentColor++;
        if (currentColor > 2) { currentColor = 0; }
        background.GetComponent<SpriteRenderer>().color = colors[currentColor];
    }

}
