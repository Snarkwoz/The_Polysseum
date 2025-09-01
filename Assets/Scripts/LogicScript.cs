using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject gameoverscreen;
    public GameObject victoryscreen;

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void gameover()
    { 
        gameoverscreen.SetActive(true); 
    }

    public void Victory()
    {
        victoryscreen.SetActive(true);
    }
}
