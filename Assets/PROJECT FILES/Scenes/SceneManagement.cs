using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //
    // To access this in any other script:
    //
    // VARIABLES
    // private GameObject SceneManagerObject;
    // private SceneManagement SceneManagerScript;
    //
    // START
    // SceneManagerObject = GameObject.Find("SceneManager");
    // SceneManagerScript = SceneManagerObject.GetComponent<SceneManagement>();
    //

    // Put all scenes and their names in this array with the same order as enum
    private string[] SceneNames = {"StartingScene", "PlayScene"};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangeToScene(SceneEnum sceneID)
    {
        int ID = (int)sceneID;
        SceneManager.LoadScene(SceneNames[ID]);
    }
}
