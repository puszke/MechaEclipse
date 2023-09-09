using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public float health = 5;
    public GameObject bloodParticle, bloodDecal;
    public Material glow;
    private Material normalMat;
    public SkinnedMeshRenderer targetMesh;
    public GameObject currency;
    [SerializeField] private bool cMesh = false;
    
    // Start is called before the first frame update
    void Start()
    {
        normalMat = targetMesh.material;
    }
    
    IEnumerator Glow()
    {
        GameObject newBlood = Instantiate(bloodParticle);
        GameObject newBloodDecal = Instantiate(bloodDecal);
        newBlood.transform.position = transform.position;
        newBloodDecal.transform.position = new Vector3(transform.position.x+Random.Range(-8,8), 0, transform.position.z + Random.Range(-8, 8));
        targetMesh.material = glow;
        yield return new WaitForSeconds(0.1f);
        targetMesh.material = normalMat;
        Destroy(newBlood, 4);
        Destroy(newBloodDecal, 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Kill")
        {
            DealDamage(999);
        }
    }
    public void DealDamage(float amount)
    {
        health -= amount;
        
        if(health<0)
        {
            GameObject newCurrency = Instantiate(currency, transform.position, Quaternion.identity);
            
            StageManager.instance.DestroyEnemyCheck();
            Destroy(this.gameObject);
        }
        StartCoroutine(Glow());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
