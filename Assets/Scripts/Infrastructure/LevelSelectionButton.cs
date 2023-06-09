using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class LevelSelectionButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private QuestionDataSo levelQuestion;

        public event Action<List<QuestionInfo>> LevelSelected;

        public void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            LevelSelected?.Invoke(levelQuestion.GetQuestionInfo);
        }
    }
}