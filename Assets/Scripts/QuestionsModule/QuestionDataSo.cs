using System.Collections.Generic;
using UnityEngine;

namespace QuestionsModule
{
    [CreateAssetMenu(fileName = "QuestionsData", menuName = "ScriptableObjects/QuestionsData", order = 2)]
    public class QuestionDataSo : ScriptableObject
    {
        [SerializeField] private int level;
        [SerializeField] private List<QuestionInfo> questions;

        public int Level => level;

        public List<QuestionInfo> GetQuestionInfo => questions;
    }
}