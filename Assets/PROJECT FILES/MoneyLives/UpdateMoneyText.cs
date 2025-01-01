using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoneyText : MonoBehaviour
{
    // Money Script Vairable
    private MoneyHandler moneyScript;

    private int currentBalance;

    // Start is called before the first frame update
    void Start()
    {
        // access money handler
        moneyScript = gameObject.GetComponent<MoneyHandler>();

        // setup intial balance
        currentBalance = moneyScript.CheckBalance();
    }

    // Update is called once per frame
    void Update()
    {
        // If money has changed value
        if(currentBalance != moneyScript.CheckBalance())
        {
            // update the text to match
            UpdateText();
            currentBalance = moneyScript.CheckBalance();
        }
    }

    void UpdateText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "£" + moneyScript.CheckBalance().ToString();
    }
}
