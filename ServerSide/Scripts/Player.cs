using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public string username;
    public CharacterController controller;
    public float gravity = -9.81f;
    public float moveSpeed = 5f;
    private bool[] inputs;
    public float jumpSpeed = 5f;
    private float yVelocity = 0;
    private Vector3 fromPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private float lastTime;

    private void Start()
    {
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        moveSpeed *= Time.fixedDeltaTime;
        jumpSpeed *= Time.fixedDeltaTime;
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        inputs = new bool[5];
    }

    public void SetPosition(Vector3 position)
    {
        fromPos = toPos;
        toPos = position;
        lastTime = Time.time;
    }

    public void FixedUpdate()
    {
        Vector2 _inputDirection = Vector2.zero;
        if (inputs[0])
        {
            _inputDirection.y += 1;
        }
        if (inputs[1])
        {
            _inputDirection.y -= 1;
        }
        if (inputs[2])
        {
            _inputDirection.x -= 1;
        }
        if (inputs[3])
        {
            _inputDirection.x += 1;
        }
        Move(_inputDirection);
    }
    private void Move(Vector2 _inputDirection)
    {
        

        toPos = transform.right * _inputDirection.x + transform.forward * _inputDirection.y;
        toPos *= moveSpeed;

        if (controller.isGrounded)
        {
            yVelocity = 0f;
            if (inputs[4])
            {
                yVelocity = jumpSpeed;
            }
        }
        yVelocity += gravity;
        toPos.y = yVelocity;
        toPos = Vector3.Lerp(fromPos, toPos, (Time.time - lastTime) / (1.0f / Constants.TICKS_PER_SEC));
        controller.Move(toPos);
        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }

    public void SetInput(bool[] _inputs, Quaternion _rotation)
    {
        inputs = _inputs;
        transform.rotation = _rotation;
    }
}
