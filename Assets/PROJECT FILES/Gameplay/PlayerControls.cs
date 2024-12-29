using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameDataObject;
    private GameData gameDataInstance;

    private InputHandler playerInputs;
    private bool onGround;
    private bool Landed;


    void Start()
    {
        onGround = false;
        Landed = true;
        playerInputs = gameObject.GetComponent<InputHandler>();

        gameDataObject = GameObject.Find("GameplayData");
        gameDataInstance = gameDataObject.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputs.JumpTriggered)
        {
            if(onGround)
            {
                onGround = false;
                Landed = false;
                gameObject.GetComponent<Rigidbody2D>().velocityY = 10.0f;
                gameDataInstance.playerInAir = true;
                gameDataInstance.DestroyPlatform();
            }
        }

        if(!Landed)
        {
            gameDataInstance.TrackCamera(gameObject.GetComponent<Transform>().position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        Landed = true;
        gameDataInstance.playerInAir = false;
        gameDataInstance.SpawnNextPlatform();

        if (collision.gameObject.tag == "Platform")
        {
            print("Hit Moving Platform");
            gameDataInstance.IncrementScore();
        }
    }
}
