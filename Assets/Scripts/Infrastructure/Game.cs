using System;
using System.Collections;
using PlayerModule;
using QuestionsModule;
using UIModule;
using UnityEngine;
using UnityEngine.UI;



namespace Infrastructure
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private EnemiesSpawner enemiesSpawner;
        [SerializeField] private Car player;
        [SerializeField] private Text scoreText;
        [SerializeField] private QuestionsUI questionUIPanel;

        private const int MaxCountOfResurrect = 3;
        private LevelData _currentLevelData;
        private int _score;
        private bool _gameInProcess;
        private Coroutine _scoreCounterCoroutine;
        private int _countOfLose;
        
        public event Action GameCompleted;
        public event Action GameLost;
        public event Action Answered;
        public event Action QuestionActivated;


        public void StartGame(LevelData levelData)
        {
            _currentLevelData = levelData.Copy();
            
            scoreText.gameObject.SetActive(true);
            
            _score = 0;
            scoreText.text = "0";
            
            _countOfLose = 0;
            _gameInProcess = true;
            
            questionUIPanel.Init(levelData.Questions);
            questionUIPanel.AnswerSelected += OnAnswerSelected;
            
            _scoreCounterCoroutine = StartCoroutine(ScoreNumerable());
            
            enemiesSpawner.StartSpawn();
            Time.timeScale = 1;
            player.gameObject.SetActive(true);
            player.Died += LoseGame;
        }

        public void StopGame()
        {
            scoreText.gameObject.SetActive(false);
            _gameInProcess = false;
            StopCoroutine(_scoreCounterCoroutine);
            questionUIPanel.AnswerSelected -= OnAnswerSelected;
            questionUIPanel.gameObject.SetActive(false);
            enemiesSpawner.StopSpawn();
            enemiesSpawner.Clear();
            player.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }

        private void OnAnswerSelected(bool answerIsCorrect)
        {
            if (answerIsCorrect)
            {
                ResumeGame();
                questionUIPanel.gameObject.SetActive(false);
                Answered?.Invoke();
            }
            else
            {
                StopGame();
            }
        }

        public void ResumeGame()
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
            }
        }

        private void CompleteGame()
        {
            StopGame();
            GameCompleted?.Invoke();
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            scoreText.text = "Your score: " + _score;
        }
        
        private void LoseGame()
        {
            PauseGame();

            if (++_countOfLose > MaxCountOfResurrect)
            {
                StopGame();
                GameLost?.Invoke();
                return;
            }
            
            questionUIPanel.gameObject.SetActive(true);
            questionUIPanel.GenerateQuest();
            QuestionActivated?.Invoke();
        }
    }
}