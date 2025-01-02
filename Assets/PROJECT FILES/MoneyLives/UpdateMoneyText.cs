using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoneyText : MonoBehaviour
{
    [SerializeField]    
    private int currentBalance;

    // Start is called before the first frame update
    void Start()
    {
        // setup intial balance
        currentBalance = MoneyManager.instance.CheckBalance();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        currentBalance = MoneyManager.instance.CheckBalance();
        UpdateText();
    }

    void UpdateText()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "£" + currentBalance.ToString();
    }
}
