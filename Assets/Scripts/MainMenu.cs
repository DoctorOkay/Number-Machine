using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ActivateGame()
    {
        SceneManager.LoadScene("NM_NumberMachine", LoadSceneMode.Single);
    }
}
