using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficultybutton : MonoBehaviour
{
    private Button button;
    public int difficulty;
    private  GameManager gamemanager;
    void Start()
    {
        gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        button=GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void SetDifficulty()
    {
        gamemanager.startgame(difficulty);
        
    }
}
