using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    public Sounds sounds;
    public GameObject ball;
    public GameObject ballPlaceholder;
    public float speed = 5;
    public bool ballHasBeenShot;
    private float x;

    public bool provokeCrowd;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ballPlaceholder = GameObject.Find("BallPlaceholder");
        sounds = FindObjectOfType<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        RunningWithBall();
        ResetIfMissed();
        if (Input.GetMouseButton(0) && !ballHasBeenShot)
        {
            provokeCrowd = true;
            transform.position = new Vector3(x , transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        x = Input.mousePosition.x / 100;
        if (x >= 2)
        {
            x = 2;
        }
        if (x <= -2)
        {
            x = -2;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ShootBall();
        }
    }

    void RunningWithBall()
    {
        if(ball != null)
        {
            ball.transform.position = ballPlaceholder.transform.position;
        }
    }
    void ResetIfMissed()
    {
        if (transform.position.y >= 1.5f && ball == null && !ballHasBeenShot)
        {
            gameManager.resetPlay = true;
        }
    }
    void ShootBall()
    {
        if (ball != null)
        {
            sounds.PlayShotSound();
            ball.GetComponent<BallSqueeze>().PlayAnimation();
            ball.GetComponent<Ball>().moveTowardsGoal = true;
            ballHasBeenShot = true;
            ball = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") && !collision.gameObject.GetComponent<Ball>().moveTowardsGoal)
        {
            ball = collision.gameObject;
        }
    }
}
