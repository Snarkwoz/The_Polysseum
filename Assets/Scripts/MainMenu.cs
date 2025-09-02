using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads each level
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

    // Closes the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
