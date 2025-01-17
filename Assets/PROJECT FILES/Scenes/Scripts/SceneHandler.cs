using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    private string[] SceneNames = { "ProfileSelect", "StartingScene", "PlayScene" };
    private enum SceneID { ProfileSelect, StartingScene, PlayScene};


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
