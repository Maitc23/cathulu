using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame() 
    {
        SceneManager.LoadScene("Cathulu");
    }

    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Si sale este mensaje, significa que sirve uwu");
    }
}
