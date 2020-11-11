using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnPlant : MonoBehaviour
{
    private int minD = -100;
    private int maxD = 100;
    public GameObject applePlant;
    public GameObject pearPlant;
    private int maxPlants = 5;
    public int numPlants = 0;
    private float appleMinSpawnTime = 20;
    private float appleMaxSpawnTime = 40;
    private float pearMinSpawnTime = 40;
    private float pearMaxSpawnTime = 80;
    private float appleNextSpawnTime = 0;
    private float pearNextSpawnTime = 30;
    private float appleLastSpawnTime = 0;
    private float pearLastSpawnTime = 0;
    private int minRadius = 40;
    private float timeSinceLastCheck = 0;

    // Update is called once per frame
    void Update()
    {
        CheckPlantSpawn();
    }

    public void CheckPlantSpawn()
    {
        if (numPlants < maxPlants)
        {
            
            timeSinceLastCheck = Time.deltaTime;
            appleLastSpawnTime += timeSinceLastCheck;
            pearLastSpawnTime += timeSinceLastCheck;
            if (appleLastSpawnTime >= appleNextSpawnTime)
            {
                ApplePlantSpawn();
            }
            if (pearLastSpawnTime >= pearNextSpawnTime)
            {
                PearPlantSpawn();
            }
        }
    }

    bool CheckSurroundings(GameObject test)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
        foreach(GameObject obj in objects)
        {
            if (obj != test)
            {
                if (Vector3.Distance(test.transform.position, obj.transform.position) < minRadius)
                    return false;
            }
        }
        return true;
    }

    public void ApplePlantSpawn()
    {
        bool valid = false;
        GameObject newPlant;
        do
        {
            newPlant = Instantiate(applePlant);
            newPlant.transform.position = new Vector3(Random.Range(minD, maxD), 0, Random.Range(minD, maxD));
            if (CheckSurroundings(newPlant))
                Destroy(newPlant);
            else
                valid = true;
        } while (valid == false);
        appleNextSpawnTime = Random.Range(appleMinSpawnTime, appleMaxSpawnTime);
        appleLastSpawnTime = 0;
    }

    public void PearPlantSpawn()
    {
        bool valid = false;
        GameObject newPlant;
        do
        {
            newPlant = Instantiate(pearPlant);
            newPlant.transform.position = new Vector3(Random.Range(minD, maxD), 0, Random.Range(minD, maxD));
            if (CheckSurroundings(newPlant))
                Destroy(newPlant);
            else
                valid = true;
        } while (valid == false);
        pearNextSpawnTime = Random.Range(pearMinSpawnTime, pearMaxSpawnTime);
        pearLastSpawnTime = 0;
    }
}
