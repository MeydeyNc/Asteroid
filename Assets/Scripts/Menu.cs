using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{


    public void Setup()
    {
        gameObject.SetActive(true);

    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Asteroid");
    }

    public void Quit()
    {
        Application.Quit();
    }


}