using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Class isn't accessible as it seems!
    public GameObject enemyPrefab;
    bool isSpawn = true;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomSpawn());
    }

    IEnumerator RandomSpawn()
    {
        yield return new WaitForSeconds(6f);
        if (!isSpawn)
        {
            float randPosX = Random.Range(-9, 9);
            float randPosY = Random.Range(-2, 3.5f);
            Vector3 randPos = new Vector3(randPosX, randPosY);
            Instantiate(enemyPrefab, randPos, Quaternion.identity);
            isSpawn = true;
        }
        yield return new WaitForSeconds(6);
        isSpawn=false;
    }
}
