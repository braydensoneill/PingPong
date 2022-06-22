using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public PlayerScore playerScoreScript;
    public PlayerScore enemyScoreScript; 

    public TextMeshProUGUI scoreText;
    private int playerScore;
    private int enemyScore;

    // Start is called before the first frame update
    void Start()
    {
        playerScoreScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        enemyScoreScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<PlayerScore>();

        InitialiseText();
    }

    // Update is called once per frame
    void Update()
    {
        playerScore = playerScoreScript.GetScore();
        enemyScore = playerScoreScript.GetScore();

        SetScoreText();
    }

    private void InitialiseText()
    {
        playerScore = 0;
        enemyScore = 0;

        SetScoreText();   }

    private void SetScoreText()
    {
        scoreText.text = playerScore.ToString() + " - " + enemyScore.ToString();
    }
}
