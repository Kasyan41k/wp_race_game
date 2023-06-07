using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule.Data
{
    [Serializable]
    public class LevelSelectData
    {
        [SerializeField] private int levelId;
        [SerializeField] private Button levelSelectButton;

        public event Action<int> LevelSelected;
        
        public void Init()
        {
            levelSelectButton.onClick.AddListener(OnSelectButtonClicked);
        }

        private void OnSelectButtonClicked()
        {
            LevelSelected?.Invoke(levelId);
        }

        public int LevelId => levelId;
        public Button LevelSelectButton => levelSelectButton;
    }
}