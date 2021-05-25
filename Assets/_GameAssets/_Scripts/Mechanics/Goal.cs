using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    [SerializeField]
    float radius;
    [SerializeField]
    GameObject player;

    AudioSource audioSource;
    bool isOver;

	// Use this for initialization
	void Start () {
        player =  GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance<radius && !isOver)
        {
            isOver = true;
            player.GetComponent<CharacterController>().enabled = false;
            audioSource.Play();
            Invoke("LoadVictoryScene", 3f);
        }
	}

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
