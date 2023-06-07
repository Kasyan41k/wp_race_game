using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts
{
    [CreateAssetMenu(fileName = "QuestionsData", menuName = "ScriptableObjects/QuestionsData", order = 1)]
    public class QuestionDataSo : ScriptableObject
    {
        [SerializeField] private int level;
        [SerializeField] private List<QuestionInfo> questions;


        public int Level => level;

        public List<QuestionInfo> GetQuestionInfo => questions;
    }
}
