using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text scoreTextInGame, scoreTextAfterGame;
    [SerializeField] private Questions questionPanel;
    


    public float carSpeed;
    Vector2 carPosition;

    private int  score = 0;


    void Start()
    {
        carPosition = transform.position;
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(ScoreNumerable());

        questionPanel.AnswerSelected += OnAnswerSelected;

        //questionPanel.AnswerSelected
    }

    private void OnAnswerSelected(bool answerIsCorrect)
    {
        if (answerIsCorrect)
        {
            ResumeGame();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }


    private void ResumeGame()
    {
        questionPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        carPosition.x += Input.GetAxis("Horizontal") * carSpeed;

        carPosition.x = Mathf.Clamp(carPosition.x, -2.39f, 2.39f);

        transform.position = carPosition;
    }

    private IEnumerator ScoreNumerable()
    {
        yield return new WaitForSeconds(0.75f);
        score++;
        scoreTextInGame.GetComponent<Text>().text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
        StartCoroutine(ScoreNumerable());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy Car") 
        {
            Destroy(col.gameObject);
            LoseGame();
        }
    }

    private void LoseGame()
    {
        Time.timeScale = 0f;
        scoreTextAfterGame.text = "Your score:\n" + score.ToString();
        PlayerPrefs.SetInt("Speed", 0);
        questionPanel.gameObject.SetActive(true);
        questionPanel.InitializeQuest();
    }

}
