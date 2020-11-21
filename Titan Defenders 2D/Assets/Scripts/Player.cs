using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    Vector2 direction;
    public float speed,fireRate;
    public GameObject bullet, bulletSpawner;
    private float timer;

    public int maxHealth = 100;
    public int currentHealth;

    public healthbar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        player.MovePosition(player.position + direction * speed * Time.deltaTime);

        //Check if the "Fire1" button is pressed
        if(Input.GetAxis("Fire1") > 0 && timer > fireRate)
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            //reset timer
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    //implement damage by using collider with enemy//

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
