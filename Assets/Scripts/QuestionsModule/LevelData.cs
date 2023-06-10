using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestionsModule
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private int maxScore;
        [SerializeField] private List<QuestionInfo> questions;

        public int MaxScore => maxScore;
        public List<QuestionInfo> Questions => questions;

        public LevelData(LevelData levelData)
        {
            maxScore = levelData.maxScore;
            questions = levelData.questions;
        }
        
        public LevelData Copy()
        {
            return new LevelData(this);
        }
    }
}