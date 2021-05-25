using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    [SerializeField]
    float lifeTime = 5f;
    [SerializeField]
    GameObject explotionPrefab;
    [SerializeField]
    int damage = 1;


    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider collider)
    {

        EntityLife el = collider.GetComponent<EntityLife>();
        if (el)
        {
            collider.gameObject.GetComponent<EntityLife>().GetDamage(damage);
        }


        GameObject boom = Instantiate(explotionPrefab, transform.position,Quaternion.identity);
        Destroy(boom,1f);

        Destroy(gameObject);

    }
}
