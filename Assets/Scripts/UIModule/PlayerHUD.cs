using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Button pauseButton;

        public event Action PauseButtonClicked;
        
        public void Init()
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);   
        }

        private void OnPauseButtonClicked()
        {
            PauseButtonClicked?.Invoke();
        }

        public void SetPauseButton(bool isActive)
        {
            pauseButton.gameObject.SetActive(isActive);
        }
    }
}