using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeUI : MonoBehaviour {

    public Color healthyColor = Color.green;
    public Color dyingColor = Color.red;

    EntityLife life;
    Image lifeBar;

	// Use this for initialization
	void Start () {
        life = GetComponentInParent<EntityLife>();
        lifeBar = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        float lifePercent = (float)life.currentLife / life.maxLife;
        lifeBar.fillAmount = lifePercent;

        if (lifePercent>0.5)
        {
            lifeBar.color = healthyColor;
        }
        else
        {
            lifeBar.color = dyingColor;
        }
	}
}
