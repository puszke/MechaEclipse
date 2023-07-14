using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public int value = 10;
    public bool seekPlayer = false;
    private Transform player;
    float speed = 0;
    
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
        value = PlayerStats.instance.currency_drop;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(seekPlayer)
        {
            speed += 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, player.position,speed*Time.deltaTime);
        }
    }
}
