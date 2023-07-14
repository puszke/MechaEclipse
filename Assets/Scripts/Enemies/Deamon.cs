using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deamon : MonoBehaviour
{
    private Transform player;
    private bool run = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(5);
        run = !run;
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Vector3.Distance(transform.position,player.position)>3)
            transform.LookAt(player);
        if (run)
        {
            if(rb.velocity.magnitude<10)
                rb.AddRelativeForce(new Vector3(0, 0, -10), ForceMode.Impulse);
        }
        else
        {

        }
    }
}
