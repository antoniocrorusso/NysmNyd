using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int scoreNumber;

    private void Update()
    {
        scoreText.text = scoreNumber.ToString();

        if (scoreNumber < 0)
        {
            scoreNumber = 0;
        }
    }

    public void increaseScore(int ammount)
    {
        scoreNumber += ammount;
    }

    public void decreaseScore(int ammount)
    {
        scoreNumber -= ammount;
    }


}
