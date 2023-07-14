using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void LoadLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Map"));
        Object[] maps = Resources.LoadAll("Maps/");

        GameObject map = maps[Random.Range(0, maps.Length)] as GameObject;

        GameObject newMap = Instantiate(map);
        newMap.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(StartSpawning());
    }
    IEnumerator StartSpawning()
    {
        transform.position = new Vector3(0, -99, 0);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < 50; i++)
        {
            Object[] enemies = Resources.LoadAll("Enemies/");
            Debug.Log(enemies);
            GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length - 1)] as GameObject);
            newEnemy.transform.position = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));

            yield return new WaitForSeconds(0.1f);
        }
            //StartCoroutine(SpawnEnemies());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
