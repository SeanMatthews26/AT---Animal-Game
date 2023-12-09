using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] animal;

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

        while(canSpawn)
        {
            yield return wait;

            Spawn();
        }
    }

    private void Spawn()
    {
        //Generate Random Animal
        int randAnimal = Random.Range(0, animal.Length);
        GameObject spawningAnimal = animal[randAnimal];

        int animalSpawnPosInt = Random.Range(1, 5);
        //int animalSpawnPosInt = 4;
        Vector2 animalSpawnPos;


        switch(animalSpawnPosInt)
        {

            case 1:
                //Top
                animalSpawnPos= new Vector2(Random.Range(-8, 8), 6.5f);
                Instantiate(spawningAnimal, animalSpawnPos, Quaternion.identity);

                break;

            case 2:
                //Bottom
                animalSpawnPos = new Vector2(Random.Range(-8, 8), -6.5f);
                Instantiate(spawningAnimal, animalSpawnPos, Quaternion.identity);

                break;

            case 3:
                //Left
                animalSpawnPos = new Vector2(-10, Random.Range(-4, 4));
                Instantiate(spawningAnimal, animalSpawnPos, Quaternion.identity);

                break;

            case 4:
                //Right
                animalSpawnPos = new Vector2(10, Random.Range(-4, 4));
                Instantiate(spawningAnimal, animalSpawnPos, Quaternion.identity);

                break;

        }


    }
}
