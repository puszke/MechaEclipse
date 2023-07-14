using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int value = 10;
    bool seekPlayer = true;
    private Transform player;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerStats.instance.currency += value;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(seekPlayer)
        {
            speed += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, player.position,speed*Time.deltaTime);
        }
    }
}
