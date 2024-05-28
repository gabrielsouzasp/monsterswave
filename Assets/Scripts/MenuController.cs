using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        BaseScript.LoadLevelScene = "Level1";
        SceneManager.LoadScene("Loading");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
