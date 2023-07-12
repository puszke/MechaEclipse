using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 5;
    public Material glow;
    private Material normalMat;
    // Start is called before the first frame update
    void Start()
    {
        normalMat = GetComponent<MeshRenderer>().material;
    }
    IEnumerator Glow()
    {
        GetComponent<MeshRenderer>().material = glow;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().material = normalMat;
    }
    public void DealDamage(float amount)
    {
        health -= amount;
        StartCoroutine(Glow());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
