using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textscore;


    public void AddScore()
    {
        score++;
        textscore.text = score.ToString();
    }


}