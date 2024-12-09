using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private InputHandler playerInputs;

    private bool onGround;
    private float playerGravity;
    private float playerVelocity;

    void Start()
    {
        onGround = true;
        playerGravity = 0.15f;
        playerVelocity = 0.0f;
        playerInputs = gameObject.GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs.JumpTriggered)
        {
            onGround = false;
            playerVelocity = 12.0f;
        }

        if (!onGround)
        {
            Vector3 NewPos = transform.position;
            gameObject.GetComponent<Transform>().position = new Vector3(NewPos.x, NewPos.y + (Time.deltaTime * playerVelocity), NewPos.z);
            playerVelocity -= playerGravity;
            print(playerVelocity);
        }
    }
}
