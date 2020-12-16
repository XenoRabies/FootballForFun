using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSqueeze : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void PlayAnimation(){
        animator.SetTrigger("playAnim");
        Invoke("StopAnimation", 0.1f);
    }
    private void StopAnimation(){
        animator.ResetTrigger("playAnim");
    }
}
