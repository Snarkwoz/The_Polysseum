using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LogicScript : MonoBehaviour
{
    // Getting screens for game over and victory
    public GameObject gameoverscreen;
    public GameObject victoryscreen;
    public TextMeshProUGUI health_display;

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

    public void GetHealthDisplay(string health)
    {
        health_display.text = health;
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
