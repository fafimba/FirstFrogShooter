using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Web : TriggerByDistance{

    [SerializeField]
    float slowRate;
    [SerializeField]
    float fadeInSpeed = 2;
    [SerializeField]
    float deepOffset = 2f;

FirstPersonController player;
  
    public float lifeTime;

    float playerRunBaseSpeed;
    float playerWalkBaseSpeed;


    void Awake()
    {
 
       player = FindObjectOfType<FirstPersonController>();
       playerRunBaseSpeed = player.p_RunSpeed;
      playerWalkBaseSpeed = player.p_WalkSpeed;
    }

   IEnumerator Start()
   {
     
     while (transform.localScale.x < 6)
     {
         transform.localScale += Vector3.one * Time.deltaTime * fadeInSpeed;
         yield return new WaitForSeconds(Time.deltaTime/3);
     }

       StartCoroutine(SlowPlayer());
        yield return new WaitForSeconds(lifeTime);
        StopCoroutine(SlowPlayer());

        player.m_RunSpeed = playerRunBaseSpeed;
        player.m_WalkSpeed = playerWalkBaseSpeed;
        Destroy(gameObject);
   }


    IEnumerator SlowPlayer()
    {
       while (true)
        {
            CheckTrigger();

            if (isInside && (transform.position.y + deepOffset) > player.transform.position.y)
            {

                player.m_RunSpeed = playerRunBaseSpeed / slowRate;
                player.m_WalkSpeed = playerWalkBaseSpeed / slowRate;
            }
            else
            {
                player.m_RunSpeed = playerRunBaseSpeed;
                player.m_WalkSpeed = playerWalkBaseSpeed;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
      }
}
