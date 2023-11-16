using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControls : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Player Scene");
        SceneManager.LoadScene("VillageCentre", LoadSceneMode.Additive);
    }
}
