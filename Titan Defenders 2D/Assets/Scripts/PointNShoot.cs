using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNShoot : MonoBehaviour
{
    public GameObject playerPosition;
    public GameObject reticle; 
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
        float playerRotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // value which is used to point player sprite (which is at the reticle)
        playerPosition.transform.rotation = Quaternion.Euler(0.0f, 0.0f, playerRotation);
    }
}
