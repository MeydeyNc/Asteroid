using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
  
    public void RestartButton()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("Asteroid");
    }

    public void ExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
