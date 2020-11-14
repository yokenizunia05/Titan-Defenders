using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    
    private Vector2 target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector2(10, 0);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
