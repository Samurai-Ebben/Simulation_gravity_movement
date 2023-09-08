using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstaShit : MonoBehaviour 
{
    public GameObject enemyPrefab;
    bool isSpawn = false;
    public Transform[] spawnPoints;
    // Update is called once per frame
    void Update()
    {
        int randPos = Random.Range(0, spawnPoints.Length-1);
        StartCoroutine(RandomSpawn(spawnPoints[randPos]));
    }

    IEnumerator RandomSpawn(Transform pos)
    {
        if (!isSpawn)
        {
            isSpawn = true;
            Instantiate(enemyPrefab, pos.position, Quaternion.identity);
            yield return new WaitForSeconds(4f);
            isSpawn = false;
        }
    }
}
