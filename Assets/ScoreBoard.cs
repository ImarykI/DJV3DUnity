using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    int score;

    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        //scoreText = GetComponent<TMP_Text>();
        scoreText.SetText("000");
    }

    public void IncreaseScore(int amount) {
        score += amount;
        if (score < 10)
        {
            scoreText.SetText($"00{score}");

        }
        else if (score < 100)
        {
            scoreText.SetText($"0{score}");
        }
        else scoreText.SetText(score.ToString());
    }
}
