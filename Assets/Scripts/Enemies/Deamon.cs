using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deamon : MonoBehaviour
{
    private Transform player;
    private bool run = true;
    private Rigidbody rb;
    private EnemyHealth health;
    public GameObject balls;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ChangeState());
    }
    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5);
        run = !run;
        if (run)
        {
            StartCoroutine(Shoot());
        }
        else
            StartCoroutine(ChangeState());
    }
    IEnumerator Shoot()
    {
        balls.SetActive(true);
        yield return new WaitForSeconds(3);
        balls.SetActive(false);
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
        if (run)
        {
            if(rb.velocity.magnitude<5)
                rb.AddRelativeForce(new Vector3(0, 0, -5), ForceMode.Impulse);
        }
        else
        {

        }
    }
}
