using System.Collections.Generic;
using QuestionsModule;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionsData", menuName = "ScriptableObjects/QuestionsList", order = 2)]
public class QuestionsList : ScriptableObject
{
    [SerializeField] private List<QuestionDataSo> questionDataSos;
    
    public List<QuestionDataSo> GetQuestionInfos() => questionDataSos;
}