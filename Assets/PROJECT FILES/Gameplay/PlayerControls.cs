using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game Camera")]
    [SerializeField] private Camera gameCamera;
    private GameData gameDataInstance;


    private InputHandler playerInputs;
    private bool onGround;


    void Start()
    {
        onGround = false;
        playerInputs = gameObject.GetComponent<InputHandler>();
        gameDataInstance = gameCamera.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs.JumpTriggered)
        {
            if(onGround)
            {
                onGround = false;
                gameObject.GetComponent<Rigidbody2D>().velocityY = 7.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        gameDataInstance.IncrementScore();
    }
}
