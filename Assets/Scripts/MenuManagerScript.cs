using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void GoBack()
    {
        GameStatistick.score = 0;
        GameStatistick.level = 1;
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
       Application.Quit();
    }
}
