using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rastreador : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float followSpeed = 0.1f;
    private bool seguir = false;
    public int health;
    public int maxHealht = 30;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealht;
        seguir = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posToGo = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        // Move the camera towards the player's position
        // Lerp is used to smoothly transition the camera position
        if (seguir == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, posToGo, followSpeed*Time.deltaTime);
        }
    }

    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            seguir = true;
        }
    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 10;
            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
