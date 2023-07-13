using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    private EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();     
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
    void CheckHealth()
    {
        if(enemyHealth.health<=0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        transform.LookAt(player);

        rb.AddRelativeForce(new Vector3(0, 0, 10));
    }
}
