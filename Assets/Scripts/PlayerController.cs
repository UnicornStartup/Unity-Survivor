using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public float playerSpeed =3f;

    private Vector2 joystickVector;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        JoystickController.onTouch += handleOnTouch;
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
            rb.velocity = new Vector2(joystickVector.x * playerSpeed, joystickVector.y * playerSpeed);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
