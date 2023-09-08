using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]float speed = 2.5f;
    Transform target;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dire = target.position - transform.position;
        dire.Normalize();
        rb.velocity = dire * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Laser>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }

}
