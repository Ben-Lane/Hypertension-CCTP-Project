using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneHandler;

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

            //Delete loading Screen
                        
        }
        else
        {
            //Load into rest of game as profile exists
            sceneHandler.EnterStartingScene();
        }

        //Once all is loaded, delete loading screen
    }

    public void SaveData()
    {
        //Save Every Type of Data
        SaveSystem.SaveProfileData(profile);
    }

    public void ClearData()
    {
        print("Old Profile");
        print(profile.age);
        print(profile.height);
        print(profile.weight);
        print(profile.daily_steps[0]);

        SaveSystem.ClearProfileData();
        UnityEditor.AssetDatabase.Refresh();
        profile = new UserProfileData();
        sceneHandler.EnterProfileSelectScene();

        print("Reset Profile");
        print(profile.age);
        print(profile.height);
        print(profile.weight);
        print(profile.daily_steps[0]);
    }

    public void OnApplicationQuit()
    {
        // If on profile select screen (there is no save data), so do not save the empty profile
        if (SceneManager.GetActiveScene().name != sceneHandler.SceneNames[(int)SceneID.ProfileSelect]) SaveData();
    }

    public SceneHandler ChangeScene()
    {
        return sceneHandler;
    }

    public void SetupProfile(UserProfileData data)
    {
        profile = data;
        SaveData();
        sceneHandler.EnterStartingScene();

        print("New Profile");
        print(profile.age);
        print(profile.height);
        print(profile.weight);
        print(profile.daily_steps[0]);
    }

    private void printProfileData()
    {
        print("Profile Data");
        print(profile.age);
        print(profile.height);
        print(profile.weight);
        print(profile.daily_steps[0]);
    }
}
