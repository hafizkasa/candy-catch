using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    [SerializeField]
    float spawnInterval;

    public GameObject[] Candies;

    public static CandySpawner instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartspawnCandies();
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void spawnCandy()
    {
        int rand = Random.Range(0, Candies.Length);

        float randx = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randx, transform.position.y, transform.position.z);


        Instantiate(Candies[rand], randomPos, transform.rotation);
    }

    IEnumerator spawnCandies()
    {
        yield return new WaitForSeconds(1.5f);

        while (true)
        {
            spawnCandy();

            yield return new WaitForSeconds(spawnInterval);

        }
    }

    public void StartspawnCandies()
    {
        StartCoroutine("spawnCandies");
    }
    public void StopspawnCandies()
    {
        StopCoroutine("spawnCandies");
    }
}
