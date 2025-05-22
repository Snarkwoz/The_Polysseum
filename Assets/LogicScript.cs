using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public void restartgame()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
