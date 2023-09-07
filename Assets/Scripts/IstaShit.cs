using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstaShit : MonoBehaviour
{
    public GameObject enemyPrefab;
    bool isSpawn = false;

    // Update is called once per frame
    void Update()
    {
        float randPosX = Random.Range(-20, 90);
        float randPosY = Random.Range(-2, 35f);
        Vector3 randPos = new Vector3(randPosX, randPosY);
        StartCoroutine(RandomSpawn(randPos));
    }

    IEnumerator RandomSpawn(Vector3 pos)
    {
        if (!isSpawn)
        {
            isSpawn = true;
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(4f);
            isSpawn = false;
        }
    }
}
