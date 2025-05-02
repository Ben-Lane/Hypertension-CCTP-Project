using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_ProgressBarCalc : MonoBehaviour
{
    private float progress;
    private float increment;
    private float max_progress;
    public float step_goal;
    public TextMeshProUGUI text_goal;
    private float factor;

    // Start is called before the first frame update
    void Start()
    {
        step_goal = DataManager.instance.getProfileSteps();
        text_goal.text = "Target Steps: " + step_goal.ToString();

        //initialise variables 400 = bar width (20 x 20)
        increment = 20; //bar height / bar additions to width
        factor = increment / step_goal; // factor used to determine goal and chunk size
        progress = increment * factor; //how much is added to width per click
        max_progress = increment * increment; //width of full bar

        //initialise progress bar
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddProgress()
    {
        progress += (increment * factor);
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
