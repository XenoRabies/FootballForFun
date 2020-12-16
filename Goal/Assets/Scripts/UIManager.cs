using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RawImage goalImage;
    [SerializeField] private RawImage confettiImage;
    [SerializeField] private RawImage loseImage; 

    private Color transparent;

    private Color initialColor;

    private void Awake(){
        initialColor = goalImage.color;
        loseImage.color = transparent;
        goalImage.color = transparent;
        confettiImage.color = transparent;
    }

    public void WinAnimation(){
        goalImage.color = initialColor;
        confettiImage.color = initialColor;
    }
    public void LoseAnimation(){
        loseImage.color = initialColor;
    }
}
