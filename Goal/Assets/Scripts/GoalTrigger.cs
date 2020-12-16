using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private GameManager gameManager;
    private Keeper keeper;
    public bool goal;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        keeper = FindObjectOfType<Keeper>();
    }
    void Update()
    {
        if(goal)
        {
            keeper.speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            gameManager.score += 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            goal = true;
            collision.gameObject.GetComponent<Ball>().moveTowardsGoal = false;
        }
    }
}
