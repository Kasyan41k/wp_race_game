using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIModule
{
    public class QuestionsUI : MonoBehaviour
    {
        private QuestionInfo[] _questionsArray;
        [SerializeField] private Text question;
        [SerializeField] private Button answer1Button;
        [SerializeField] private Button answer2Button;
        [SerializeField] private Button answer3Button;

        [SerializeField] private Text answer1Text;
        [SerializeField] private Text answer2Text;
        [SerializeField] private Text answer3Text;

        public event Action<bool> AnswerSelected;

        private QuestionInfo _currentQuest;

        private void Start()
        {
            answer1Button.onClick.AddListener(() => OnAnswerSelected(1));
            answer2Button.onClick.AddListener(() => OnAnswerSelected(2));
            answer3Button.onClick.AddListener(() => OnAnswerSelected(3));
        }

        public void Init(List<QuestionInfo> questionInfos)
        {
            _questionsArray = questionInfos.ToArray();
        }

        public void GenerateQuest()
        {
            _currentQuest = _questionsArray[UnityEngine.Random.Range(0, _questionsArray.Length)];

            question.text = _currentQuest.Question;

            answer1Text.text = _currentQuest.Answer1;
            answer2Text.text = _currentQuest.Answer2;
            answer3Text.text = _currentQuest.Answer3;
        }

        private void OnAnswerSelected(int check)
        {
            AnswerSelected?.Invoke(_currentQuest.CorrectAnswerIndex == check);
        }
    }
}
