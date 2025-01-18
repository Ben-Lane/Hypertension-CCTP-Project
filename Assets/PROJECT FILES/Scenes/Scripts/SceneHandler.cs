using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    public string[] SceneNames = { "ProfileSelect", "StartingScene", "PlayScene" };
    public enum SceneID { ProfileSelect, StartingScene, PlayScene};

    private GameObject enterTransition;
    private GameObject exitTransition;


    public void EnterProfileSelectScene()
    {
        SceneManager.LoadScene(SceneNames[(int)SceneID.ProfileSelect]);
    }

    public void EnterStartingScene()
    {
        SceneManager.LoadScene(SceneNames[(int)SceneID.StartingScene]);
    }

    public void EnterPlayScene()
    {
        SceneManager.LoadScene(SceneNames[(int)SceneID.PlayScene]);
    }


}
