using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<EnemyController> enemies = new List<EnemyController>();

    public static GameManager Instance;

    public int score = 0;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI livesTxt;


    public GameObject pickPrefab;

    public bool isPickup = false;

    public Assignment5 player;

    public float playersHealth = 3;
    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "Score: " + score.ToString();
        livesTxt.text = "Lives: " + playersHealth.ToString();
        StartCoroutine(SpawnPickUp());
    }

    IEnumerator SpawnPickUp()
    {
        yield return new WaitForSeconds(3);
        if(!isPickup)
        {
            isPickup = true;
            var pickup =Instantiate(pickPrefab, new Vector2(Random.Range(-15, 15), Random.Range(-5, 5)), Quaternion.identity);
            yield return new WaitForSeconds(10);
            Destroy(pickup, 10);
            yield return new WaitForSeconds(5);
            isPickup = false;
        }
    }


    public void Death()
    {
        if (player.health < 0)
        {
            Debug.Log("Dead");
        }
        else
        {
            player.Death();
        }
    }
}
