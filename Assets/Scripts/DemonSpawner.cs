using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject demon;

    [SerializeField] private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        int demonSpawnPosInt = Random.Range(1, 5);
        Vector2 demonSpawnPos;


        switch (demonSpawnPosInt)
        {

            case 1:
                //Top
                demonSpawnPos = new Vector2(Random.Range(-8, 8), 6.5f);
                Instantiate(demon, demonSpawnPos, Quaternion.identity);

                break;

            case 2:
                //Bottom
                demonSpawnPos = new Vector2(Random.Range(-8, 8), -6.5f);
                Instantiate(demon, demonSpawnPos, Quaternion.identity);

                break;

            case 3:
                //Left
                demonSpawnPos = new Vector2(-10, Random.Range(-4, 4));
                Instantiate(demon, demonSpawnPos, Quaternion.identity);

                break;

            case 4:
                //Right
                demonSpawnPos = new Vector2(10, Random.Range(-4, 4));
                Instantiate(demon, demonSpawnPos, Quaternion.identity);

                break;

        }


    }
}
