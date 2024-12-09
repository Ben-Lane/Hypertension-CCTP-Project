using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Player Score UI")]
    [SerializeField] private TextMeshProUGUI player_score;

    [Header("Moving Platform Prefab")]
    [SerializeField] private GameObject movingPlatformPrefab;

    [Header("Player Character")]
    [SerializeField] private GameObject playerCapsule;

    //Existing Platforms
    private GameObject nextPlatform;
    [SerializeField] private GameObject currentPlatform;

    //GameVariables
    private bool nextPlatformHasCollider;

    public bool playerInAir { get; set; }

    void Start()
    {
        if (player_score != null)
        {
            player_score.text = "0";
        }

        nextPlatformHasCollider = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInAir && !nextPlatformHasCollider)
        {
            if(nextPlatform.transform.position.y < playerCapsule.transform.position.y)
            {
                print("Player above next platform, spawn collision");
                Destroy(currentPlatform);
                nextPlatform.AddComponent<BoxCollider2D>();
                nextPlatformHasCollider = true;
            }
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
        nextPlatform = Instantiate(movingPlatformPrefab);
    }


}
