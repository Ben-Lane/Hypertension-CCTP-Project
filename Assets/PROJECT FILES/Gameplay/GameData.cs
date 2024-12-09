using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Player Score UI")]
    [SerializeField] private TextMeshProUGUI player_score; 

    void Start()
    {

        if (player_score != null)
        {

            player_score.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        if(int.TryParse(player_score.text, out int current_score))
        {
            player_score.text = (current_score + 1).ToString();
        }
    }
}
