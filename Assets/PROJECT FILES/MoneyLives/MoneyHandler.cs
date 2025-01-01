using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{

    private static int money;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int TopUpMoney(int amount)
    {
        money += amount;
        return money;
    }

    public int SpendMoney(int amount)
    {
        money -= amount;
        return money;
    }

    public int CheckBalance()
    {
        return money;
    }
}
