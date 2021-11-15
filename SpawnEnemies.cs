using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject [] enemies;
    // Start is called before the first frame update


    void Start()
    {
            if(GameObject.FindGameObjectsWithTag("SpawnPoints").Length != 0 )
        {
            Debug.Log("A");
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("SpawnPoints").Length; i++)
            {
                spawnPoints.Add(GameObject.FindGameObjectsWithTag("SpawnPoints")[i]);
            }

            StartCoroutine(SpawingRandom());
        }else
        {
            Debug.LogWarning("Pon Spawn en el juego");
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawingRandom()
    {
        while (true)
        {
            int spawnrandom = Random.Range(0, spawnPoints.Count);
            int Enemyrandom = Random.Range(0, enemies.Length);
            yield return new WaitForSeconds(Random.Range(1, 5));
            Instantiate(enemies[Enemyrandom], spawnPoints[spawnrandom].transform);
        }

    }
}
