using System;
using System.Collections.Generic;
using QuestionsModule;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class LevelSelectionButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private LevelDataSo levelDataSo;

        public event Action<LevelData> LevelSelected;

        public void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            LevelSelected?.Invoke(levelDataSo.LevelData);
        }
    }
}