using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    
    private int money;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        money = 0;
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
