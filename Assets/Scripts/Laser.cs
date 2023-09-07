using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject explosion; //Reference to our explosion object

    // Start is called before the first frame update
    void Start()
    {
        //Destroy ourself after 7 seconds
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        //Move in the direction of our own up direction
        transform.position += transform.up * 20 * Time.deltaTime;
    }

    //Unity Collision function
    //Called when a rigidbody2D gameObject collides with a collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Change our color to green
        GetComponent<SpriteRenderer>().color = Color.green;

        //Create a new explosion and save that explosion in a variable.
        GameObject newExplosion = Instantiate(explosion, transform.position, transform.rotation);

        //Destroy the newly created explosion object after 1 second.
        Destroy(newExplosion, 1);
    }
}
