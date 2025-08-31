using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void StartLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
