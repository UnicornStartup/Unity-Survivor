using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerController playerController;
    public float backgroundSpeed = 10f;

    private Vector2 joystickVector;
    private Rigidbody2D rb;
    public Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        JoystickController.onTouch += handleOnTouch;
        playerController = GetComponent<PlayerController>();

    }

    void FixedUpdate()
    {
        playerMovement();
    }

    void handleOnTouch(Vector2 joystickVector)
    {
        this.joystickVector = joystickVector;
    }

    void playerMovement()
    {
        if (joystickVector.y != 0 || joystickVector.x != 0)
        {
            Vector2 movement = new Vector2(joystickVector.x * playerController.stats.getvalue(StatType.MoveSpeed), joystickVector.y * playerController.stats.getvalue(StatType.MoveSpeed));
            rb.velocity = movement;
            moveBackground(new Vector2(joystickVector.x / backgroundSpeed, joystickVector.y / backgroundSpeed));
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void moveBackground(Vector2 movement)
    {
        Transform quad = transform.Find("Quad");
        Material material = quad.GetComponent<Renderer>().material;
        material.mainTextureOffset += movement;
    }
}
