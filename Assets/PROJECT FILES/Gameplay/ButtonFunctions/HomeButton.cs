using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
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
        DataManager.instance.ChangeScene().EnterStartingScene();
    }
}
