using System;
using System.Collections;
using System.Collections.Generic;
using PlayerModule;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private EnemiesSpawner enemiesSpawner;
        [SerializeField] private Car player;
        [SerializeField] private Text scoreTextInGame;
        [SerializeField] private Questions questionPanel;

        private int _score = 0;
        private bool _gameIsProcess;

        public event Action GameEnd;

        private int _countOfLose;

        public void StartGame(List<QuestionInfo> questionInfos)
        {
            scoreTextInGame.gameObject.SetActive(true);
            _countOfLose = 0;
            _gameIsProcess = true;
            PlayerPrefs.SetInt("Score", 0);
            StartCoroutine(ScoreNumerable());
            questionPanel.Init(questionInfos);
            questionPanel.AnswerSelected += OnAnswerSelected;
            enemiesSpawner.StartSpawn();
            player.gameObject.SetActive(true);
            player.Died += LoseGame;
        }

        public void StopGame()
        {
            scoreTextInGame.gameObject.SetActive(false);
            _gameIsProcess = false;
            GameEnd?.Invoke();
            questionPanel.AnswerSelected -= OnAnswerSelected;
            questionPanel.gameObject.SetActive(false);
            enemiesSpawner.StopSpawn();
            player.gameObject.SetActive(false);
        }

        private void OnAnswerSelected(bool answerIsCorrect)
        {
            if (answerIsCorrect)
            {
                ResumeGame();
            }
            else
            {
                StopGame();
            }
        }

        private void ResumeGame()
        {
            questionPanel.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        
        private IEnumerator ScoreNumerable()
        {
            while (_gameIsProcess)
            {
                yield return new WaitForSeconds(0.75f);
                _score++;
                scoreTextInGame.text = _score.ToString();
                PlayerPrefs.SetInt("Score", _score);
            }
        }
        
        private void LoseGame()
        {
            Time.timeScale = 0f;
            scoreTextInGame.text = "Your score: " + _score;
            PlayerPrefs.SetInt("Speed", 0);

            if (++_countOfLose > 3)
            {
                StopGame();
                return;
            }
                
            
            questionPanel.gameObject.SetActive(true);
            questionPanel.GenerateQuest();
        }
    }
}