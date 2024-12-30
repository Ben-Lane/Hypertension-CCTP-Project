using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMovement : MonoBehaviour
{
    private GameObject gameDataObject;
    private GameData gameDataInstance;

    private Vector2 edgeMinMax;
    private float halfWidth;
    private int moveDirection;
    private float moveSpeed;

    // boolean for movement
    public bool Moving { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //if gameplay data object exists, save the reference for use
        gameDataObject = GameObject.Find("GameplayData");
        gameDataInstance = gameDataObject.GetComponent<GameData>();

        //Variable setup
        halfWidth = (GetComponent<SpriteRenderer>().bounds.size.x / 2);
        edgeMinMax = new Vector2(transform.position.x - (gameDataInstance.platform_width/2), transform.position.x + (gameDataInstance.platform_width / 2));
        moveDirection = 1;
        moveSpeed = 2.5f;
        Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving) MovePlatform();       
    }

    void MovePlatform()
    {
        //move platform
        Vector3 nextPosition = new Vector3(transform.position.x + (moveDirection * moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        transform.position = nextPosition;

        //flips direction if it is beyond bounds now
        if (nextPosition.x < edgeMinMax.x || nextPosition.x > edgeMinMax.y)
        {
            moveDirection *= -1;
        }
    }
}
