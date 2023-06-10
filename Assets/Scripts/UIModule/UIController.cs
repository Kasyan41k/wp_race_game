using System.Collections.Generic;
using Infrastructure;
using QuestionsModule;
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
        [SerializeField] private FinishUI finishUI;

        private void Start()
        {
            startGameMenuUI.PlayClicked += OpenLevelSelectionMenu;
            levelSelectUI.LevelSelected += OnLevelSelected;
            
            game.GameLost += LoadMainMenu;
            game.GameCompleted += OnGameCompleted;

            finishUI.Init();
            finishUI.ReturnToLevelSelectionButtonClicked += OpenLevelSelectionMenu;
        }

        private void OnGameCompleted()
        {
            finishUI.gameObject.SetActive(true);
        }


        private void LoadMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
            startGameMenuUI.gameObject.SetActive(true);
        }

        private void OnLevelSelected(LevelData levelData)
        {
            game.StartGame(levelData);
            levelSelectUI.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(false);
        }

        public void OpenLevelSelectionMenu()
        {
            mainMenu.gameObject.SetActive(true);
            levelSelectUI.gameObject.SetActive(true);
            startGameMenuUI.gameObject.SetActive(false);
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