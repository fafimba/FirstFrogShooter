using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            FinishGame();
        }
    }

    public void FinishGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("River");
    }
}
