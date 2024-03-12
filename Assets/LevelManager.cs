using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void EndScene()
    {
        Application.Quit();
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("Main");
    }
}
