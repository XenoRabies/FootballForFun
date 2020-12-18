using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private GameManager gameManager;
    private Keeper keeper;
    private Player player;
    private Ball ball;
    public AudioSource shotSound;
    public AudioSource goalSound;
    public AudioSource missSound;
    public AudioSource crowdSound;
    public float crowdVolume;
    public bool playGoalSound;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        keeper = FindObjectOfType<Keeper>();
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        if(gameManager.goalTrigger.goal)
        {
            playGoalSound = false;
        }
        if(playGoalSound)
        {
            goalSound.mute = true;
            PlayGoalSound();
        }
        else
        {
            goalSound.mute = false;
        }

        if(!keeper.touchedBall)
        {
            missSound.mute = true;
            PlayMissSound();
        }
        else
        {
            missSound.mute = false;
        }

        crowdSound.volume = crowdVolume / 2;
        if (!player.provokeCrowd)
        {
            PlayCrowdSound();
            crowdSound.mute = true;
        }
        else
        {
            crowdVolume += Time.deltaTime;
            crowdSound.mute = false;
        }
        if(crowdVolume >= 1)
        {
            crowdVolume = 1;
        }

        if(ball.moveTowardsGoal)
        {
            crowdVolume -= Time.deltaTime * 12;
        }
    }

    public void PlayShotSound()
    {
        shotSound.Play();
    }

    public void PlayGoalSound()
    {
        goalSound.Play();
    }

    public void PlayMissSound()
    {
        missSound.Play();
    }

    public void PlayCrowdSound()
    {
        crowdSound.Play();
    }
}
