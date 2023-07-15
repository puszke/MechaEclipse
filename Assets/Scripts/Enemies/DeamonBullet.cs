using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeamonBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(0, 0, 1), ForceMode.Impulse);
    }
}
