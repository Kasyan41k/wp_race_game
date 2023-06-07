using System;
using System.Collections.Generic;
using UIModule.Data;
using UnityEngine;

namespace UIModule
{
    public class LevelSelectUI : MonoBehaviour
    {
        [SerializeField] private List<LevelSelectData> levelsSelectData;

        public event Action<int> LevelSelected;
        
        public void Start()
        {
            foreach (var levelSelectData in levelsSelectData)
            {
                levelSelectData.Init();
                levelSelectData.LevelSelected += OnLevelSelected;
            }
        }

        private void OnLevelSelected(int levelId)
        {
            LevelSelected?.Invoke(levelId);
        }
    }
}
