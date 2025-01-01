using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndUIScoreUpdate : MonoBehaviour
{
    // GameData Variables
    private GameObject gameDataObject;
    private GameData gameDataInstance;

    // Start is called before the first frame update
    void Start()
    {
        // Game Data Variables
        gameDataObject = GameObject.Find("GameplayData");
        gameDataInstance = gameDataObject.GetComponent<GameData>();

        gameObject.GetComponent<TextMeshProUGUI>().text = gameDataInstance.AccessScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
