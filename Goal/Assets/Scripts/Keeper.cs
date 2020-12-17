using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    private GameManager gameManager;

    public float speed;
    public bool switchDirection;
    public bool touchedBall;

    public float keeperAnimationTimer;
    public int keeperAnimationFrame;
    public Sprite keeper1;
    public Sprite keeper2;
    public Sprite keeper3;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
        Animate();
    }
    void Behavior()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if (transform.position.x >= 2)
        {
            switchDirection = true;
        }
        if (transform.position.x <= -2)
        {
            switchDirection = false;
        }
        if (switchDirection && !touchedBall)
        {
            speed = -7;
        }
        else if (!switchDirection && !touchedBall)
        {
            speed = 7;
        }
        else if (touchedBall)
        {
            speed = 0;
        }
    }
    void Animate()
    {
        if(!gameManager.goalTrigger.goal && !touchedBall)
        {
            keeperAnimationTimer += Time.deltaTime;
        }
        if(keeperAnimationTimer >= 0.1f)
        {
            keeperAnimationFrame++;
            keeperAnimationTimer = 0;
        }
        if(keeperAnimationFrame == 0)
        {
            GetComponent<SpriteRenderer>().sprite = keeper1;
        }
        if (keeperAnimationFrame == 1)
        {
            GetComponent<SpriteRenderer>().sprite = keeper2;
        }
        if (keeperAnimationFrame == 2)
        {
            GetComponent<SpriteRenderer>().sprite = keeper3;
        }
        if (keeperAnimationFrame >= 3)
        {
            keeperAnimationFrame = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            collision.GetComponent<Ball>().moveTowardsGoal = false;
            touchedBall = true;
        }
    }
}
