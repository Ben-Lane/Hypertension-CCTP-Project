using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    //Maintain Link between Scenes
    public SceneHandler sceneHandler;

    //Save Data Classes
    private UserProfileData profile;
    

    //Setup Singleton - Data Manager
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Initialise Scene Handler
        sceneHandler = new SceneHandler();

        //LOAD OTHER DATA

        //LOAD PROFILE DATA
        profile = SaveSystem.LoadProfileData();
        if (profile == null)
        {
            profile = new UserProfileData();
        }
        else
        {
            //Load into rest of game as profile exists
            sceneHandler.EnterStartingScene();
        }

        //Once all is loaded, delete loading screen
    }

    void SaveData()
    {
        //Save Every Type of Data
        SaveSystem.SaveProfileData(profile);
    }

    void ClearData()
    {
        SaveSystem.ClearProfileData();
        profile = SaveSystem.LoadProfileData();
    }

    public void OnApplicationQuit()
    {
        SaveData();
    }

    public SceneHandler ChangeScene()
    {
        return sceneHandler;
    }
}
