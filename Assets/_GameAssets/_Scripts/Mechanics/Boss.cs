using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject webPrefab;
    [SerializeField]
    GameObject eggPrefab;
    [SerializeField]
    float shootRate;
    [SerializeField]
    float shootForce;
    [SerializeField]
    float webSpawnRate;
    [SerializeField]
    float eggSpawnRate;
    [SerializeField]
    Transform eggSpotsParent;

    Transform shootSpot;


    GameObject player;
    List<Transform> eggSpots = new List<Transform>();

    bool bQuiet;
    bool bAnnoyed;
    bool bFurius;
    bool bDeath;
    [SerializeField]
    int lifePoints = 3;
    int actualLifePoints;

    void Awake()
    {
        player = GameObject.Find("Player");
        shootSpot = transform.Find("ShootSpot");
        actualLifePoints = lifePoints;
    }

    void Start()
    {
      
        for (int i = 0; i < eggSpotsParent.childCount; i++)
        {
            eggSpots.Add(eggSpotsParent.transform.GetChild(i).transform);
        }
        SetState();
        StartCoroutine(QuietState());
        StartCoroutine(AnnoyedState());
        StartCoroutine(FuriusState());
    }

    void Update()
    {
        transform.LookAt(player.transform.position + Vector3.down);
        if (bDeath)
        {
            SceneManager.LoadScene("GameOver");
          
        }   
    }

    public void GetDamage(int damage)
    {
        actualLifePoints -= damage;
       
        SetState();
    }

    void SetState()
    {
        bQuiet = actualLifePoints <= lifePoints ? true : false;
        bAnnoyed = actualLifePoints <= (lifePoints * 0.70) ? true : false;
        bFurius = actualLifePoints <= (lifePoints * 0.40) ? true : false;
        bDeath = actualLifePoints <= 0 ? true : false;
    }

    IEnumerator QuietState()
    {
        while (true)
        {
            while (bQuiet)
            {
                yield return StartCoroutine(Shoot());
            }
            yield return new WaitForSeconds(.5f);
        }
    }


    IEnumerator AnnoyedState()
    {
        while (true)
        {
            while (bAnnoyed)
            {
                yield return StartCoroutine(SpawnWeb());
            }
            yield return new WaitForSeconds(.5f);
        }
    }


    IEnumerator FuriusState()
    {
        while (true)
        {
            while (bFurius)
            {
                yield return StartCoroutine(SpawnEgg());
            }
            yield return new WaitForSeconds(.5f);
        }
    }

    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootSpot.position, transform.rotation);
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        if (rbBullet)
        {
            rbBullet.AddForce(transform.forward * shootForce, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(shootRate);
    }

    IEnumerator SpawnWeb()
    {
        GameObject web = Instantiate(webPrefab, player.transform.position, Quaternion.identity);
        web.GetComponent<Web>().target = player.transform;
        web.transform.position += Vector3.down * 0.5f;
        yield return new WaitForSeconds(webSpawnRate);
    }

    IEnumerator SpawnEgg()
    {
        for (int i = 0; i < eggSpots.Count; i++)
        {
            Vector3 newEggPosition = eggSpots[i].position;
            Vector2 randomPosition = Random.insideUnitCircle * 3;
            newEggPosition += new Vector3(randomPosition.x, -1, randomPosition.y);

            GameObject egg = Instantiate(eggPrefab);
            egg.transform.position = newEggPosition;
        }

        yield return new WaitForSeconds(eggSpawnRate);
    }
}
