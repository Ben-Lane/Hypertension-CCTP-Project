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
    private float spawn_point;

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

        // Create Variables
        float randomDirection = Random.Range(0.0f, 1.0f);
        if (randomDirection < 0.05f) moveDirection = 1;
        else moveDirection = -1;

        // setup speed
        float randomSpeed = Random.Range(1.0f, 2.5f);
        moveSpeed = randomSpeed;

        // Setup spawn point
        float randomSpawn = Random.Range(edgeMinMax.x, edgeMinMax.y);
        spawn_point = randomSpawn;

        // initiate movement
        Moving = true;

        // set position
        transform.position = new Vector3(spawn_point, transform.position.y, transform.position.z);
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
