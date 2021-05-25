using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : EntityLife {

    [SerializeField]  AudioSource audioSource;

    protected override void Dye()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public override void GetDamage(int damage)
    {
        audioSource.PlayOneShot(audioSource.clip);
        base.GetDamage(damage);
    }
}
