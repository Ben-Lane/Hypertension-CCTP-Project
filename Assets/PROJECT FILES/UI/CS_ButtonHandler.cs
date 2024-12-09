using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CS_ButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject ProgressBar;
    private CS_ProgressBarCalc progressScript;


    // Start is called before the first frame update
    void Start()
    {
        progressScript = ProgressBar.GetComponent<CS_ProgressBarCalc>();

        Button MainButton = GetComponent<Button>();
        MainButton.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonClicked()
    {
        progressScript.AddProgress();
    }
}
