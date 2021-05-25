using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{

    [SerializeField]
    float distance = 8f;
    [SerializeField]
    float speed = 20f;

    bool touched = false;
    bool shooted = false;

    [SerializeField]
    AudioClip shootAudioClip;

    AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        touched = true;
        if (other.tag == "TongueTarget" || other.tag == "Enemy")
        {
            other.transform.parent = transform.parent.transform.parent;
            StartCoroutine("GrapTarget", other.gameObject);
        }

    }



    IEnumerator GrapTarget(GameObject target)
    {

        while (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.parent.position) <= 0.5f)
            {
                Destroy(target);
            }
            Vector3 targetDirectionToPlayer = transform.parent.position - target.transform.position;
            targetDirectionToPlayer.Normalize();

            target.transform.Translate(targetDirectionToPlayer * Time.deltaTime * speed, Space.World);
            yield return new WaitForSeconds(0.01f);
          
        }
    }


    void Update()
    {
        int direction = 0;

        if (!shooted && Input.GetMouseButtonDown(2))
        {
            audioSource.PlayOneShot(shootAudioClip);
        }

        shooted = shooted == true || Input.GetMouseButtonDown(2) ? true : false;
        touched = touched == true || distance < transform.parent.localScale.z ? true : false;

        if (shooted && !touched)
        {
            direction = 1;
        }
        else if (transform.parent.localScale.z > 0.1)
        {
            direction = -1;
        }
        else
        {
            direction = 0;
            shooted = false;
            touched = false;
            transform.parent.localScale -= new Vector3(0, 0, transform.parent.localScale.z);
        }

        transform.parent.localScale += Vector3.forward * speed * direction * Time.deltaTime;

    }

}
