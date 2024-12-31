using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Player Score UI")]
    [SerializeField] private TextMeshProUGUI player_score;

    [Header("Moving Platform Prefab")]
    [SerializeField] private GameObject movingPlatformPrefab;

    [Header("Current Platform")]
    [SerializeField] private GameObject currentPlatform;

    [Header("Player Character")]
    [SerializeField] private GameObject playerCapsule;

    [Header("Game Camera")]
    [SerializeField] private GameObject gameCamera;

    [Header("Death Barrier")]
    [SerializeField] private GameObject deathBarrier;

    //Existing Platforms
    private GameObject nextPlatform;
    private GameObject oldPlatform;

    //GameVariables
    private bool nextPlatformHasCollider;
    private float cameraPlatformBuffer;
    private float cameraPlayerBuffer;
    private float playerBarrierBuffer;
    private float gainedHeight;

    public bool gameOver { get; private set; }

    //Variables
    public bool playerInAir { get; set; }
    public float platform_width { get; private set; }

    void Start()
    {
        if (player_score != null)
        {
            player_score.text = "0";
        }

        nextPlatformHasCollider = false;
        cameraPlatformBuffer = Mathf.Abs(currentPlatform.transform.position.y - movingPlatformPrefab.transform.position.y);
        cameraPlayerBuffer = 0f;

        platform_width = currentPlatform.GetComponent<SpriteRenderer>().bounds.size.x;

        //setup game
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextPlatform != null)
        {
            if ((playerCapsule.transform.position.y - playerCapsule.GetComponent<SpriteRenderer>().bounds.size.y / 2) >
            (nextPlatform.transform.position.y + nextPlatform.GetComponent<SpriteRenderer>().bounds.size.y / 2))
            {
                nextPlatform.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    public void IncrementScore()
    {
        float playerBottom = playerCapsule.transform.position.y - (playerCapsule.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        float platformTop = currentPlatform.transform.position.y + (currentPlatform.GetComponent<SpriteRenderer>().bounds.size.y / 2);

        if (playerBottom > platformTop)
        {
            if (int.TryParse(player_score.text, out int current_score))
            {
                player_score.text = (current_score + 1).ToString();
            }
        }
    }

    public void SpawnNextPlatform()
    {
        print("SpawnPlatform");

        // State which platform is stood on
        if (nextPlatform != null)
        {
            currentPlatform = nextPlatform;

            //disable movement on current platform
            currentPlatform.GetComponent<PlatformMovement>().Moving = false;
        }

        //Create The next Platform
        nextPlatform = Instantiate(movingPlatformPrefab);
        nextPlatform.name = "platform " + player_score.text.ToString();

        //Set Platform for deletion next time the player jumps
        oldPlatform = currentPlatform;

        nextPlatform.transform.position = new Vector3(nextPlatform.transform.position.x, nextPlatform.transform.position.y + gainedHeight, nextPlatform.transform.position.z);

        gainedHeight += cameraPlatformBuffer;
        print(gainedHeight);
    }

    public void TrackCamera(Vector3 trackPos)
    {
        //Adjust camera -> player positions while moving
        if (cameraPlayerBuffer <= 0) cameraPlayerBuffer = Mathf.Abs(gameCamera.transform.position.y - playerCapsule.transform.position.y);
        gameCamera.transform.position = new Vector3(trackPos.x, trackPos.y + cameraPlayerBuffer, gameCamera.transform.position.z);

        //find death barrier -> player distance
        if (deathBarrier.transform.position.y <= nextPlatform.transform.position.y)
        {
            if (playerBarrierBuffer <= 0) playerBarrierBuffer = Mathf.Abs(playerCapsule.transform.position.y - deathBarrier.transform.position.y); ;
            deathBarrier.transform.position = new Vector3(trackPos.x, trackPos.y - playerBarrierBuffer, deathBarrier.transform.position.z);
        }
    }

    public void DestroyPlatform()
    {
        Destroy(oldPlatform);
    }

    public void EndGame(GameObject prefab)
    {
        // End the game code
        print("Game Ended");
        gameOver = true;

        //Setup height values, to account for climbed height by player
        GameObject endUI = Instantiate(prefab);

        endUI.GetComponent<GameOverUIMovement>().endHeight = gameCamera.transform.position.y;
        endUI.GetComponent<GameOverUIMovement>().startHeight = gameCamera.transform.position.y - (gameCamera.GetComponent<Camera>().orthographicSize) - (endUI.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        endUI.transform.position = new Vector3(gameCamera.transform.position.x, endUI.GetComponent<GameOverUIMovement>().startHeight, endUI.transform.position.z);

        // Stop camera lockiing to the player
        playerCapsule.GetComponent<PlayerControls>().Landed = true;

        //start end game UI movement
        endUI.GetComponent<GameOverUIMovement>().StartMovement();

    }

    public float getCameraHeight()
    {
        return gameCamera.transform.position.y;
    }
}
