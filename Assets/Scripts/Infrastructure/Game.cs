using System;
using System.Collections;
using PlayerModule;
using QuestionsModule;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private EnemiesSpawner enemiesSpawner;
        [SerializeField] private Car player;
        [SerializeField] private Text scoreText;
        [SerializeField] private Questions questionPanel;

        private LevelData _currentLevelData;
        private int _score = 0;
        private bool _gameInProcess;
        private Coroutine _scoreCounterCoroutine;
        
        public event Action GameCompleted;
        public event Action GameLost;

        private int _countOfLose;

        public void StartGame(LevelData levelData)
        {
            _currentLevelData = levelData.Copy();
            
            scoreText.gameObject.SetActive(true);
            
            _score = 0;
            scoreText.text = "0";
            
            _countOfLose = 0;
            _gameInProcess = true;
            
            questionPanel.Init(levelData.Questions);
            questionPanel.AnswerSelected += OnAnswerSelected;
            
            _scoreCounterCoroutine = StartCoroutine(ScoreNumerable());
            
            enemiesSpawner.StartSpawn();
            player.gameObject.SetActive(true);
            //player.Reset();
            player.Died += LoseGame;
        }

        public void StopGame()
        {
            scoreText.gameObject.SetActive(false);
            _gameInProcess = false;
            StopCoroutine(_scoreCounterCoroutine);
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
                questionPanel.gameObject.SetActive(false);
            }
            else
            {
                StopGame();
            }
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
        }
        
        private IEnumerator ScoreNumerable()
        {
            while (_gameInProcess)
            {
                yield return new WaitForSeconds(0.75f);
                _score++;
                scoreText.text = _score.ToString();

                if (_score >= _currentLevelData.MaxScore)
                {
                    _score = _currentLevelData.MaxScore;
                    CompleteGame();
                    yield break;
                }
                
                //PlayerPrefs.SetInt("Score", _score);
            }
        }

        private void CompleteGame()
        {
            StopGame();
            GameCompleted?.Invoke();
        }

        private void PauseGame()
        {
            Time.timeScale = 0f;
            scoreText.text = "Your score: " + _score;
        }
        
        private void LoseGame()
        {
            PauseGame();

            if (++_countOfLose > 3)
            {
                StopGame();
                GameLost?.Invoke();
                return;
            }
            
            questionPanel.gameObject.SetActive(true);
            questionPanel.GenerateQuest();
        }
    }
}