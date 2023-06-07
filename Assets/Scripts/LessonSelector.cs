using UnityEngine;
using UnityEngine.SceneManagement;

public class LessonSelector : MonoBehaviour
{
    public void MathLesson() 
    {
        SceneManager.LoadScene(6);
    }

    public void UkrainianLanguageLesson() 
    {
        SceneManager.LoadScene(5);
    }

    public void EnglishLanguageLesson() 
    {
        SceneManager.LoadScene(4);
    }
}
