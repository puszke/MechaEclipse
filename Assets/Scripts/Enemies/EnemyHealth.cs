using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 5;
    public GameObject bloodParticle, bloodDecal;
    public Material glow;
    private Material normalMat;
    // Start is called before the first frame update
    void Start()
    {
        normalMat = GetComponent<MeshRenderer>().material;
    }
    IEnumerator Glow()
    {
        GameObject newBlood = Instantiate(bloodParticle);
        GameObject newBloodDecal = Instantiate(bloodDecal);
        newBlood.transform.position = transform.position;
        newBloodDecal.transform.position = new Vector3(transform.position.x+Random.Range(-8,8), 0, transform.position.z + Random.Range(-8, 8));
        GetComponent<MeshRenderer>().material = glow;
        yield return new WaitForSeconds(0.1f);
        GetComponent<MeshRenderer>().material = normalMat;
        Destroy(newBlood, 4);
        Destroy(newBloodDecal, 10);
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
