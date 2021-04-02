using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Scene currentScene;

    public void LoadGame()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("NM_NumberMachine", LoadSceneMode.Single);
    }

    //public void LoadRules()
    //{
    //    currentScene = SceneManager.GetActiveScene();
    //    SceneManager.LoadScene("NM_Rules", LoadSceneMode.Single);
    //    SceneManager.UnloadSceneAsync(currentScene.buildIndex);
    //}

    public void LoadWin()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("NM_GameOver", LoadSceneMode.Additive);
    }

    public void LoadMenu()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("NM_MainMenu", LoadSceneMode.Single);
    }
}
