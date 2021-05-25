using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    [SerializeField]
    GameObject explotion;
    [SerializeField]
    float lifeTime = 3f;
    [SerializeField]
    int damage=2;
    [SerializeField]
    float radius = 2;

	// Use this for initialization
	void Start () {
        Invoke("Explode", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Explode()
    {
        GameObject newExplotion = Instantiate(explotion);
        newExplotion.transform.position = transform.position;

        EnemyLife[] entities = FindObjectsOfType<EnemyLife>();
        for (int i = 0; i < entities.Length; i++)
        {
            EnemyLife entity = entities[i];
            float distance = Vector3.Distance(transform.position, entity.transform.position);
            if (distance<radius)
            {
                entity.GetDamage(damage);
            }
        }
        
        Destroy(newExplotion, 1f);
        Destroy(gameObject);
    }
}
