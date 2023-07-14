using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeamonBullet : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector3(0, 0, 1), ForceMode.Impulse);
    }
}
