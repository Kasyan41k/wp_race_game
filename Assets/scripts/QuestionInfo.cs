using System;
using UnityEngine;

[Serializable]
public class QuestionInfo
{
    [SerializeField] private string question;
    [SerializeField] private string answer1;
    [SerializeField] private string answer2;
    [SerializeField] private string answer3;
    [SerializeField] private int correctAnsIndex;

    public string Question { get { return question; } }
    public string Answer1 { get { return answer1; } }
    public string Answer2 { get { return answer2; } }
    public string Answer3 { get { return answer3; } }
    public int CorrentAnswerIndex { get { return correctAnsIndex; } }

    public QuestionInfo(string question, string ans, string ans2, string ans3, int correctAnsIndex)
    {
        this.question = question;
        this.answer1 = ans;
        this.answer2 = ans2;
        this.answer3 = ans3;
        this.correctAnsIndex = correctAnsIndex;
    }

    public QuestionInfo(QuestionInfo questionInfo)
    {
        question = questionInfo.question;
        answer1 = questionInfo.answer1;
        answer2 = questionInfo.answer2;
        answer3 = questionInfo.answer3;
        correctAnsIndex = questionInfo.correctAnsIndex;
    }

    public QuestionInfo Copy()
    {
        return new QuestionInfo(this);
    }

}
