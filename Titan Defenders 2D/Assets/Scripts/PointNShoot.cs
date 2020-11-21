using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNShoot : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject reticle;
    public GameObject bulletPrefab, bulletSpawner;
    public float bulletSpeed = 60f;
    private Vector3 mouseLoc;
    


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // hides cursor
    }
    
    // Update is called once per frame
    void Update()
    {
        mouseLoc = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)); // informs the game where the cursor is
        reticle.transform.position = new Vector2(mouseLoc.x, mouseLoc.y); // puts the reticle where the cursor is

        Vector3 difference = mouseLoc - playerPosition.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // value which is used to point player sprite (which is at the reticle)
        playerPosition.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.transform.position, bulletPrefab.transform.rotation) as GameObject;
        bullet.transform.position = playerPosition.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ -90);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; 
    }

}
