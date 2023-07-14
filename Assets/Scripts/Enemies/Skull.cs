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
        StartCoroutine(resetSpeed());
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
    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(Random.Range(4,8));
        if(Vector3.Distance(transform.position,player.position)>27)
            rb.velocity = Vector3.zero;
        StartCoroutine(resetSpeed());
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
