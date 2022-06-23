using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    //public GameObject characterObject;
    public GameObject character;

    public TextMeshProUGUI scoreText;
    private int characterScore;

    // Start is called before the first frame update
    void Start()
    {
        //characterController = GetComponent<CharacterScore>();
        InitialiseText();
    }

    // Update is called once per frame
    void Update()
    {
        characterScore = character.GetComponent<CharacterScore>().GetScore();
        SetScoreText();
    }

    private void InitialiseText()
    {
        characterScore = 0;
        SetScoreText();   
    }

    private void SetScoreText()
    {
        scoreText.text = characterScore.ToString();
    }
}
