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
        [SerializeField] private PauseMenuUI pauseMenuUI;
        [SerializeField] private PlayerHUD playerHUD;
        [SerializeField] private LessonUI lessonUI;

        private void Start()
        {
            startGameMenuUI.PlayClicked += OpenLevelSelectionMenu;
            startGameMenuUI.LessonClicked += OpenLessonMenu;
            
            levelSelectUI.LevelSelected += OnLevelSelected;
            

            InitializeGame();

            InitializeFinishUI();
            InitializePauseMenu();
            InitializePlayerHud();
            InitializeLessons();
            

            LoadMainMenu();
        }

        private void OpenLessonMenu()
        {
            lessonUI.gameObject.SetActive(true);
            startGameMenuUI.gameObject.SetActive(false);
        }

        private void InitializeLessons()
        {
            lessonUI.Init();
            lessonUI.MenuButtonClicked += LoadMainMenu;
        }

        private void InitializePauseMenu()
        {
            pauseMenuUI.Init();
            pauseMenuUI.ResumeButtonClicked += game.ResumeGame;
            pauseMenuUI.QuitToMenuButtonClicked += game.StopGame;
            pauseMenuUI.QuitToMenuButtonClicked += LoadMainMenu;
        }

        private void InitializeGame()
        {
            game.GameLost += LoadMainMenu;
            game.GameCompleted += OnGameCompleted;
            game.Answered += () => playerHUD.SetPauseButton(true);
            game.QuestionActivated += () => playerHUD.SetPauseButton(false);
        }
        
        private void InitializePlayerHud()
        {
            playerHUD.Init();
            playerHUD.PauseButtonClicked += game.PauseGame;
            playerHUD.PauseButtonClicked += ShowPause;
        }

        private void InitializeFinishUI()
        {
            finishUI.Init();
            finishUI.ReturnToLevelSelectionButtonClicked += OpenLevelSelectionMenu;
        }

        private void OnGameCompleted()
        {
            finishUI.gameObject.SetActive(true);
        }

        private void ShowPause()
        {
            pauseMenuUI.gameObject.SetActive(true);
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
            playerHUD.gameObject.SetActive(true);
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