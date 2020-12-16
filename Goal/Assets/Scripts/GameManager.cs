using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Keeper keeper;
    private GoalTrigger goalTrigger;

    private float goalTimer;

    private Text UIScore;
    [HideInInspector]
    public int score;

    public bool resetPlay;  
    void Awake()
    {
        DontDestroyOnLoad(this);
        score = PlayerPrefs.GetInt("Score", score);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            keeper = FindObjectOfType<Keeper>();
            goalTrigger = FindObjectOfType<GoalTrigger>();
            UIScore = GameObject.Find("Score").GetComponent<Text>();
            UIScore.text = score.ToString();
        }
        if(keeper.touchedBall)
        {
            PlayerPrefs.SetInt("Score", score);
            score = 0;
            goalTimer += Time.deltaTime;
            if(goalTimer > 1.5f)
            {
                goalTimer = 0;
                SceneManager.LoadScene("Game");
            }
        }
        if(goalTrigger.goal)
        {
            PlayerPrefs.SetInt("Score", score);
            goalTimer += Time.deltaTime;
            if(goalTimer > 1.5f)
            {
                goalTimer = 0;
                SceneManager.LoadScene("Game");
            }
        }
        if (resetPlay)
        {
            SceneManager.LoadScene("Game");
            resetPlay = false;
        }
    }
}
