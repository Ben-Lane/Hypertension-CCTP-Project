using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_ProgressBarCalc : MonoBehaviour
{
    private float progress;
    private float increment;
    private float max_progress;

    // Scene Management variables
    private GameObject SceneManagerObject;
    private SceneManagement SceneManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        //initialise variables 400 = bar width (20 x 20)
        increment = 20; //bar height / bar additions to width
        progress = increment * 19; //how much is added to width per click
        max_progress = increment * 20; //width of full bar

        // Scene Manager Setup
        SceneManagerObject = GameObject.Find("SceneManager");
        SceneManagerScript = SceneManagerObject.GetComponent<SceneManagement>();

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
            SceneManagerScript.ChangeToScene(SceneEnum.PlayScene);
        }
    }

    void UpdateUI()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(progress, increment);
    }
}
