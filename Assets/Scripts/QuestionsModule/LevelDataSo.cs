using UnityEngine;

namespace QuestionsModule
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
    public class LevelDataSo : ScriptableObject
    {
        [SerializeField] private LevelData levelData;

        public LevelData LevelData => levelData;

        public LevelData Copy()
        {
            return levelData.Copy();
        }
    }
}