using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public float monster_hp = 1;
    [SerializeField] private GameObject exp, part;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        GameObject newMonster = Instantiate(monster,transform.position,Quaternion.identity);
        newMonster.GetComponent<EnemyHealth>().health *= monster_hp;
        exp.SetActive(true);
        part.GetComponent<ParticleSystem>().Stop();
        Destroy(this.gameObject, 3);
    }
    
}
