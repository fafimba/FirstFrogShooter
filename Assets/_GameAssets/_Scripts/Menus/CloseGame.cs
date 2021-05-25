using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour {


     void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FinishGame()
    {
        Application.Quit();
    }
}
