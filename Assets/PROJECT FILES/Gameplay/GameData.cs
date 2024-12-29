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

    //Existing Platforms
    private GameObject nextPlatform;
    private GameObject oldPlatform;

    //GameVariables
    private bool nextPlatformHasCollider;
    private float cameraPlatformBuffer;
    private float cameraPlayerBuffer;
    private float gainedHeight;

    public bool playerInAir { get; set; }

    void Start()
    {
        if (player_score != null)
        {
            player_score.text = "0";
        }

        nextPlatformHasCollider = false;
        cameraPlatformBuffer = Mathf.Abs(currentPlatform.transform.position.y - movingPlatformPrefab.transform.position.y);
        cameraPlayerBuffer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerCapsule.transform.position.y - playerCapsule.GetComponent<SpriteRenderer>().bounds.size.y / 2) >
            (nextPlatform.transform.position.y + nextPlatform.GetComponent<SpriteRenderer>().bounds.size.y / 2))
        {
            nextPlatform.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void IncrementScore()
    {
        if(int.TryParse(player_score.text, out int current_score))
        {
            player_score.text = (current_score + 1).ToString();
        }
    }

    public void SpawnNextPlatform()
    {
        print("SpawnPlatform");

        // State which platform is stood on
        if (nextPlatform != null) currentPlatform = nextPlatform;
        print("Current Platform = " + currentPlatform.name);

        //Create The next Platform
        nextPlatform = Instantiate(movingPlatformPrefab);
        nextPlatform.name = "platform " + player_score.text.ToString();
        print("Next Platform = " + nextPlatform.name);

        //Set Platform for deletion next time the player jumps
        oldPlatform = currentPlatform;
        print("Old Platform = " + oldPlatform.name);

        nextPlatform.transform.position = new Vector3(nextPlatform.transform.position.x, nextPlatform.transform.position.y + gainedHeight, nextPlatform.transform.position.z);
        
        gainedHeight += cameraPlatformBuffer;
        print(gainedHeight);

    }

    public void TrackCamera(Vector3 trackPos)
    {
        if(cameraPlayerBuffer <= 0) cameraPlayerBuffer = Mathf.Abs(gameCamera.transform.position.y - playerCapsule.transform.position.y);
        gameCamera.transform.position = new Vector3(trackPos.x, trackPos.y + cameraPlayerBuffer, gameCamera.transform.position.z);
    }

    public void DestroyPlatform()
    {
        Destroy(oldPlatform);
    }
}
