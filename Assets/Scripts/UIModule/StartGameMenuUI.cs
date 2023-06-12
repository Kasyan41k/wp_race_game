using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class StartGameMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button lessonButton;
    
        public event Action PlayClicked;
        public event Action LessonClicked;
    
        public void Start()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            lessonButton.onClick.AddListener(OnLessonButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayClicked?.Invoke();
        }

        private void OnLessonButtonClicked()
        {
            LessonClicked?.Invoke();
        }
    }
}
