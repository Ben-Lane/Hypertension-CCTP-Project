using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScipt : MonoBehaviour
{
    //Game Data Variables
    private GameObject gameDataObject;
    private GameData gameDataInstance;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverUIPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //if gameplay data object exists, save the reference for use
        gameDataObject = GameObject.Find("GameplayData");
        gameDataInstance = gameDataObject.GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) gameDataInstance.EndGame(gameOverUIPrefab);
    }

    
}
