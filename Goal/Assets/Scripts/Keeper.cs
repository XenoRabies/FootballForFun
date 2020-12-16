using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : MonoBehaviour
{
    public float speed;
    public bool switchDirection;
    public bool touchedBall;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-2f, 2f), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        if(transform.position.x >= 2)
        {
            switchDirection = true;
        }
        if(transform.position.x <= -2)
        {
            switchDirection = false;
        }
        if(switchDirection && !touchedBall)
        {
            speed = -7;
        }
        else if(!switchDirection && !touchedBall)
        {
            speed = 7;
        }
        else if(touchedBall)
        {
            speed = 0;
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
