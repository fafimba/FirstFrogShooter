using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeUI : MonoBehaviour {

    [SerializeField]
    GameObject[] hearts;
    PlayerLife playerLife;

	// Use this for initialization
	void Awake () {
        playerLife = FindObjectOfType<PlayerLife>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerLife.currentLife)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
           
        }
	}
}
