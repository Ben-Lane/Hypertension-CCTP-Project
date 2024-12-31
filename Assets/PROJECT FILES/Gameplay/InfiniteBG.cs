using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    [Header("Bottom BG object")]
    [SerializeField] private GameObject bottomBG;

    [Header("Middle BG object")]
    [SerializeField] private GameObject middleBG;

    [Header("Top BG object")]
    [SerializeField] private GameObject topBG;

    // Access Game data
    private GameObject gameDataObject;
    private GameData gameDataInstance;

    // resolution height / 100 
    private float padding;

    // Start is called before the first frame update
    void Start()
    {
        // store game data scripts
        gameDataObject = GameObject.Find("GameplayData");
        gameDataInstance = gameDataObject.GetComponent<GameData>();

        //initialise padding
        padding = 16.12f * transform.localScale.x;
        // padding = screen.height/100

        print("Bottom BG Height: " + bottomBG.transform.position.y);
        print("Middle BG Height: " + middleBG.transform.position.y);
        print("Top BG Height: " + topBG.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // if camera is above the middle point of the middle background image
        if(gameDataInstance.getCameraHeight() > middleBG.transform.position.y)
        {
            print("Bottom BG Height: " + bottomBG.transform.position.y);
            print("Middle BG Height: " + middleBG.transform.position.y);
            print("Top BG Height: " + topBG.transform.position.y);

            //move the bottom BG image to the top
            GameObject tempBG = bottomBG;
            bottomBG = middleBG;
            middleBG = topBG;

            topBG = tempBG;
            topBG.transform.position = middleBG.transform.position;
            topBG.transform.position = new Vector3(topBG.transform.position.x, topBG.transform.position.y + padding, topBG.transform.position.z);

            print("Bottom BG Height: " + bottomBG.transform.position.y);
            print("Middle BG Height: " + middleBG.transform.position.y);
            print("Top BG Height: " + topBG.transform.position.y);
        }
    }
}
