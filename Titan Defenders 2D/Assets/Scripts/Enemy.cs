using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform defenderPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        defenderPos = GameObject.FindGameObjectWithTag("Defender").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, defenderPos.position, speed * Time.deltaTime);
    }
}
