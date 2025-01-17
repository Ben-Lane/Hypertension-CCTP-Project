using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClearDataButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button MainButton = GetComponent<Button>();
        MainButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        DataManager.instance.ClearData();
    }
}
