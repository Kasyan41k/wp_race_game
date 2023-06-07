using System;
using System.Collections;
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

        public void StartGame(int levelId)
        {
            _gameIsProcess = true;
            PlayerPrefs.SetInt("Score", 0);
            StartCoroutine(ScoreNumerable());
            questionPanel.AnswerSelected += OnAnswerSelected;
            enemiesSpawner.StartSpawn();
            player.gameObject.SetActive(true);
            player.Died += LoseGame;
        }

        public void StopGame()
        {
            _gameIsProcess = false;
            GameEnd?.Invoke();
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
            scoreTextInGame.text = "Your score:\n" + _score.ToString();
            PlayerPrefs.SetInt("Speed", 0);
            questionPanel.gameObject.SetActive(true);
            questionPanel.InitializeQuest();
        }
    }
}