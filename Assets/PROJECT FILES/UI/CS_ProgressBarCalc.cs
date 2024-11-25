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
        //initialise variables
        increment = 20;
        progress = increment;
        max_progress = increment * 20;

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
            print("Next Scene");
            SceneManager.LoadScene("PlayScene");
        }
    }

    void UpdateUI()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(progress, increment);
    }
}
