using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject laserPrefab; //Reference to our prefab (blueprint)
    public Transform gun1; //the location that we want to spawn our shots
    public Transform gun2; //the location that we want to spawn our shots
    float timer; //Time since we last fired our guns
    float fireRate = 0.8f; //How often we can fire

    // Update is called once per frame
    void Update()
    {
        //Calculate vector between mouse and player
        Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        //Rotate towards mouse code using said vector
        transform.up = direction;

        //If we hold our mouse button down and enough time has passed, then fire
        if (Input.GetMouseButton(0) && timer > fireRate)
        {
            //Reset our timer
            timer = 0;

            //Create our two bullets
            Instantiate(laserPrefab, gun1.position, transform.rotation);
            Instantiate(laserPrefab, gun2.position, transform.rotation);
        }

        //Increase our timer
        timer += Time.deltaTime;
    }
}
