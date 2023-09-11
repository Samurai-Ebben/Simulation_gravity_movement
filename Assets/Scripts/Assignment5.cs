using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Assignment5 : MonoBehaviour
{
    Vector2 position;
    Vector2 velocity;
    float gravity = 0;
    public float speed = 2f;

    bool isG = false;


    public float health = 3;
    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.playersHealth = health;

        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical") ;
        Vector2 move = new Vector2(hori, vert).normalized;

        velocity = move * speed;

        if (Input.GetKeyDown(KeyCode.G) && !isG)
        {
            gravity = 9.8f;
            isG = true;
        }
        else if (Input.GetKeyDown(KeyCode.G) && isG)
        {
            gravity = 0;
            isG = false;
        }

        velocity.y -= gravity;
        position +=  velocity * Time.deltaTime;

        BoundsCheck();
        transform.position = position;

    }

    void BoundsCheck()
    {
        //Problem screen wraping?? How?!
        float boundsY = 5;

        //y
        if (position.y < -boundsY + 0.5f)
        {
            velocity.y = -velocity.y * 1.75f * Time.deltaTime;
            position.y = -boundsY + 0.5f;
        }
        if (position.y > boundsY)
        {
            position.y = boundsY;
        }


        //x
        float boundsX = 9;
        if (position.x <= -boundsX)
        {
            position.x = 8.45f + 0.5f;
        }
        else if (position.x >= boundsX)
        {
            position.x = -8.45f - 0.5f;
        }

    }


    public void Death()
    {
        if (health < 0)
        {
            Debug.Log("Dead");
        }
        else
        {
            position = Vector3.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            Destroy(other.gameObject);
            GameManager.Instance.score += 5;
        }
        if(other.gameObject.tag == "Enemy")
        {
            health--;
            Debug.Log(health);
            Death();
        }
    }
}
