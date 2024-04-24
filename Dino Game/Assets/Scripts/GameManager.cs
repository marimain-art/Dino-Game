using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;} 

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    private float score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void UpsdateHiScore()
    {
        float hiScore = PlayerPrefs.GetFloat("hiScore", 0);

        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetFloat("hiScore", hiScore);
        }

        hiScoreText.text = Mathf.FloorToInt(hiScore).ToString("D5");
    }
}