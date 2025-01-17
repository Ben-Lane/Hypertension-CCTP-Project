using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{
    private GameObject SceneManagerObject;
    private SceneManagement SceneManagerScript;

    private UserProfileData profile;

    // Start is called before the first frame update
    void Start()
    {
        profile = SaveSystem.LoadData();
        if (profile == null) profile = new UserProfileData();

        Button MainButton = GetComponent<Button>();
        MainButton.onClick.AddListener(OnButtonClicked);

        // Setup Scene Manager Access
        SceneManagerObject = GameObject.Find("SceneManager");
        SceneManagerScript = SceneManagerObject.GetComponent<SceneManagement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonClicked()
    {
        print(profile.height);
        profile.height += 1;


        if (MoneyManager.instance.CheckBalance() > 0)
        {
            SceneManagerScript.ChangeToScene(SceneEnum.PlayScene);
            MoneyManager.instance.SpendMoney(1);
        }
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SaveData(profile);
    }
}