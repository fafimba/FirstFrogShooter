using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEgg : TriggerByDistance
{

    [SerializeField]
    GameObject spiderPrefab;


    bool isTouchedByTongue;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tongue")
        {
            isTouchedByTongue = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        CheckTrigger();

        if (isInside && !isTouchedByTongue)
        {
            StartCoroutine(BreakTheEgg());
        }
    }


    IEnumerator BreakTheEgg()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = true;
        //animator.GetLayerName

       yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        Spider spider = Instantiate(spiderPrefab, transform.position, Quaternion.identity).GetComponent<Spider>();
        if (spider)
        {
            spider.target = GameObject.Find("Player").transform;
        }
        Destroy(gameObject);
    }
}
