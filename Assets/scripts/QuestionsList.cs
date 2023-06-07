using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.scripts
{

    [CreateAssetMenu(fileName = "QuestionsData", menuName = "ScriptableObjects/QuestionsList", order = 2)]
    public class QuestionsList : ScriptableObject
    {
        
        [SerializeField] private List<QuestionDataSo> questionDataSos;


        public List<QuestionDataSo> GetQuestionInfos() => questionDataSos;
    }
}
