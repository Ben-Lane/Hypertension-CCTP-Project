using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProfileSelect : MonoBehaviour
{
    [SerializeField]
    [Header("Profile Type")]
    private profiles profileType;

    // ProfileData variables
    private PlayerProfiles profileList;
    private UserProfileData profileData;

    // Start is called before the first frame update
    void Start()
    {
        profileList = new PlayerProfiles();
        profileData = profileList.SelectProfile((int)profileType);

        //Setup Button Connection
        Button MainButton = GetComponent<Button>();
        MainButton.onClick.AddListener(OnButtonClicked);
    }

    // Button Click Event
    void OnButtonClicked()
    {
        DataManager.instance.SetupProfile(profileData);
    }
}
