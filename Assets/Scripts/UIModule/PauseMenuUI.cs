using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class PauseMenuUI : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button quitToMenuButton;

        public event Action ResumeButtonClicked;
        public event Action QuitToMenuButtonClicked;

        public void Init()
        {
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            quitToMenuButton.onClick.AddListener(OnQuitToMenuButtonClicked);
        }

        private void OnQuitToMenuButtonClicked()
        {
            QuitToMenuButtonClicked?.Invoke();
            gameObject.SetActive(false);
        }

        private void OnResumeButtonClicked()
        {
            ResumeButtonClicked?.Invoke();
            gameObject.SetActive(false);
        }
    }
}