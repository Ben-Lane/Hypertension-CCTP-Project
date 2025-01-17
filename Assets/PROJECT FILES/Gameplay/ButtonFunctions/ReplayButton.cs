using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{
    private UserProfileData profile;

    // Start is called before the first frame update
    void Start()
    {
        Button MainButton = GetComponent<Button>();
        MainButton.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonClicked()
    {
        if (MoneyManager.instance.CheckBalance() > 0)
        {
            DataManager.instance.ChangeScene().EnterPlayScene();
            MoneyManager.instance.SpendMoney(1);
        }
    }
}