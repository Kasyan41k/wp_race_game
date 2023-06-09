using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIModule
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Game game;
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private LevelSelectUI levelSelectUI;
        [SerializeField] private StartGameMenuUI startGameMenuUI;

        private void Start()
        {
            startGameMenuUI.PlayClicked += PlayGame;
            levelSelectUI.LevelSelected += OnLevelSelected;
            game.GameEnd += LoadMainMenu;
        }

        private void LoadMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
            startGameMenuUI.gameObject.SetActive(true);
        }

        private void OnLevelSelected(List<QuestionInfo> questionInfos)
        {
            game.StartGame(questionInfos);
            levelSelectUI.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(false);
        }

        public void PlayGame()
        {
            levelSelectUI.gameObject.SetActive(true);
            startGameMenuUI.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }

        public void Questions() 
        {
            SceneManager.LoadScene(3);
        }

        public void QuitGame() 
        {
            Application.Quit();
        }
    }
}