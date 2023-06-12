using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class LessonUI : MonoBehaviour
    {
        [SerializeField] private Button mathButton;
        [SerializeField] private Button englishButton;
        [SerializeField] private Button ukrainianButton;
        [SerializeField] private Button toMenuButton;

        [SerializeField] private Text mathText;
        [SerializeField] private Text englishText;
        [SerializeField] private Text ukrainianText;

        public event Action MenuButtonClicked;
        
        public void Init()
        {
            mathButton.onClick.AddListener(OnMathButtonClicked);
            englishButton.onClick.AddListener(OnEnglishButtonClicked);
            ukrainianButton.onClick.AddListener(OnUkrainianButtonClicked);
            toMenuButton.onClick.AddListener(OnMenuButtonClicked);
        }

        private void OnMenuButtonClicked()
        {
            MenuButtonClicked?.Invoke();
            Disable();
        }
        
        private void OnMathButtonClicked()
        {
            SetButtonActive(false);
            mathText.gameObject.SetActive(true);
        }

        private void OnEnglishButtonClicked()
        {
            SetButtonActive(false);
            englishText.gameObject.SetActive(true);
        }

        private void OnUkrainianButtonClicked()
        {
            SetButtonActive(false);
            ukrainianText.gameObject.SetActive(true);
        }

        public void Disable()
        {
            mathText.gameObject.SetActive(false);
            englishText.gameObject.SetActive(false);
            ukrainianText.gameObject.SetActive(false);

            SetButtonActive(true);
            
            gameObject.SetActive(false);
        }

        private void SetButtonActive(bool isActive)
        {
            mathButton.gameObject.SetActive(isActive);
            englishButton.gameObject.SetActive(isActive);
            ukrainianButton.gameObject.SetActive(isActive);
        }
    }
}