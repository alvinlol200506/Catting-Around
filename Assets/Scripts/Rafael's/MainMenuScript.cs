using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Settings() { }
    public void Exit()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
