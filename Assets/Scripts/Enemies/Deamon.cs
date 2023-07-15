using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deamon : MonoBehaviour
{
    private Transform player;
    private bool run = true;
    private Rigidbody rb;
    private EnemyHealth health;
    public GameObject balls, ball;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Shoot());
    }
    
    IEnumerator Shoot()
    {
        balls.SetActive(true);
        yield return new WaitForSeconds(3);
        GameObject newBullet = Instantiate(ball,balls.transform.position,Quaternion.identity);
        Destroy(newBullet, 2);
        balls.SetActive(false);
        StartCoroutine(Shoot());
    }
    // Update is called once per frame
    void Update()
    {
        if(health.health<=0)
        {
            Destroy(this.gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        transform.LookAt(player);
        
    }
}
