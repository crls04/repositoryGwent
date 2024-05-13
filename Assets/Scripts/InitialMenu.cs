using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
   public void ButtonPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ButtonExit()
    {
        Debug.Log("Salimos del programa");
        Application.Quit();
    }
}
