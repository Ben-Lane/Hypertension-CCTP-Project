using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_ProgressBarCalc : MonoBehaviour
{
    private float progress;
    private float increment;
    private float max_progress;

    // Start is called before the first frame update
    void Start()
    {
        //initialise variables 400 = bar width (20 x 20)
        increment = 20; //bar height / bar additions to width
        progress = increment; //how much is added to width per click
        max_progress = increment * 20; //width of full bar

        //initialise progress bar
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddProgress()
    {
        progress += increment;
        UpdateUI();

        //Check if Progress Full
        if (progress >= max_progress)
        {
            //Activate Next Scene
            MoneyManager.instance.TopUpMoney(1);
            ResetProgress();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(progress, increment);
    }

    void ResetProgress()
    {
        progress = 0;
    }
}
