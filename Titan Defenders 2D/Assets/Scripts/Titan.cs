using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MonoBehaviour
{
    public float speed;
    private Transform playerPosition;
    public GameObject titanCrawler;
    public int crawlerHealth;
   
    void Start()
    {
        
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, speed * Time.deltaTime);
        Vector3 difference = playerPosition.position - titanCrawler.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            crawlerHealth--;
            if (crawlerHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
