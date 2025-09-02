using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // Getting screens for game over and victory
    public GameObject gameoverscreen;
    public GameObject victoryscreen;

    // Resets current scene
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Goes to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Triggers game over screen
    public void gameover()
    { 
        gameoverscreen.SetActive(true); 
    }

    // Triggers victory screen
    public void Victory()
    {
        victoryscreen.SetActive(true);
    }
}
