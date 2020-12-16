using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Player player;
    public bool moveTowardsGoal;
    public float speed = 20;

    public GameObject goalShootPoint;

    public float ballAnimationTimer;
    public int ballAnimationFrame;

    public Sprite ball1;
    public Sprite ball2;
    public Sprite ball3;
    // Start is called before the first frame update
    void Start()
    {
        goalShootPoint = GameObject.Find("GoalShootPoint");
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowardsGoal)
        {
            transform.position = Vector3.MoveTowards(transform.position, goalShootPoint.transform.position, speed * Time.deltaTime * 3);
        }
        AnimateBall();
    }
    void AnimateBall()
    {
        if (player.ball != null || moveTowardsGoal)
        {
            ballAnimationTimer += Time.deltaTime;
        }
        if (ballAnimationTimer >= 0.2f)
        {
            ballAnimationFrame++;
            ballAnimationTimer = 0;
        }
        if (ballAnimationFrame == 0)
        {
            GetComponent<SpriteRenderer>().sprite = ball1;
        }
        if (ballAnimationFrame == 1)
        {
            GetComponent<SpriteRenderer>().sprite = ball2;
        }
        if (ballAnimationFrame == 2)
        {
            GetComponent<SpriteRenderer>().sprite = ball3;
        }
        if (ballAnimationFrame >= 3)
        {
            ballAnimationFrame = 0;
        }
    }
}
