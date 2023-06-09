using System;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

namespace UIModule
{
    public class LevelSelectUI : MonoBehaviour
    {
        [SerializeField] private List<LevelSelectionButton> levelsSelectButtons;

        public event Action<List<QuestionInfo>> LevelSelected;
        
        public void Start()
        {
            foreach (var levelSelectButton in levelsSelectButtons)
            {
                levelSelectButton.LevelSelected += OnLevelSelected;
            }
        }

        private void OnLevelSelected(List<QuestionInfo> questionInfos)
        {
            LevelSelected?.Invoke(questionInfos);
        }
    }
}
