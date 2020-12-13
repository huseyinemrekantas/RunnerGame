using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public int Score = 0;
    Text ScoreText;
    GameObject score;
    public bool GameOver = false;
    public float doorZ;
    public int deleteChildCount = 0;


    GameObject planePrefab;

    private void Awake()
    {
        FixedStart();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
        DontDestroyOnLoad(this);
    }

    public void FixedStart()
    {
        score = GameObject.FindGameObjectWithTag("score");
        ScoreText = score.GetComponent<Text>();
        planePrefab = GameObject.FindGameObjectWithTag("Road");
    }



    public void scoreUp()
    {
        Score += 10;
        ScoreText.text = "Score: " + Score.ToString();
    }



}
