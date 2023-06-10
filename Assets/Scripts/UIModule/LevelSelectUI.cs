using System;
using System.Collections.Generic;
using Infrastructure;
using QuestionsModule;
using UnityEngine;

namespace UIModule
{
    public class LevelSelectUI : MonoBehaviour
    {
        [SerializeField] private List<LevelSelectionButton> levelsSelectButtons;

        public event Action<LevelData> LevelSelected;
        
        public void Start()
        {
            foreach (var levelSelectButton in levelsSelectButtons)
            {
                levelSelectButton.LevelSelected += OnLevelSelected;
            }
        }

        private void OnLevelSelected(LevelData levelData)
        {
            LevelSelected?.Invoke(levelData);
        }
    }
}
