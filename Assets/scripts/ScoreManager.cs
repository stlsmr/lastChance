using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;
    public bool scoreIncrease;

    public bool shouldDouble;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncrease)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }
        //scoreCount += pointsPerSecond * Time.deltaTime;
        scoreText.text = "Счет: " + Mathf.Round(scoreCount);
        hiScoreText.text = "Лучший Счет: " + Mathf.Round(hiScoreCount);
    }
    public void AddScore(int pointsToAdd)
    {
        if (shouldDouble)
        {
            //pointsToAdd = pointsToAdd * 2;
            pointsToAdd = pointsToAdd + 100;
        }
        scoreCount += pointsToAdd;
    }
}
