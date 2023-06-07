using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class StartGameMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;
    
        public event Action PlayClicked;
    
        public void Start()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayClicked?.Invoke();
        }
    }
}
