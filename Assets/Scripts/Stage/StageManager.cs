using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    [SerializeField] private GameObject monsterSpawner;
    public int eNumber = 10;
    public int currentEliteMax = -1;
    public int currentEnemies = 0;
    public bool spawning = false;
    public List<StageDifficulty> stages;
    public StageDifficulty currentStage;

    [System.Serializable]
    public class StageDifficulty
    {
        public string name = "E";
        public int max_enemy_count = 30;
        public int max_elite_count = 5;
        public float max_enemy_hp_scaling = 1.25f;
        public float currency_drop = 1;
        public int sub_stages = 1;
    }
    private void Awake()
    {
        instance = this;
    }
    void LoadStageProperties()
    {
        eNumber += 5;
        currentEliteMax += 2;
        eNumber = Mathf.Clamp(eNumber, 0, currentStage.max_enemy_count);
        currentEliteMax = Mathf.Clamp(currentEliteMax, 0, currentStage.max_elite_count);
    }
    public void LoadLevel()
    {
        Destroy(GameObject.FindGameObjectWithTag("Map"));
        LoadStageProperties();

        Object[] maps = Resources.LoadAll("Maps/");

        GameObject map = maps[Random.Range(0, maps.Length)] as GameObject;

        GameObject newMap = Instantiate(map);
        newMap.transform.position = new Vector3(0, 0, 0);
        StartCoroutine(StartSpawning());
    }
    public void DestroyEnemyCheck()
    {
        currentEnemies--;
        if (currentEnemies <= 0)
        {
            foreach(GameObject c in GameObject.FindGameObjectsWithTag("Currency"))
            {
                c.GetComponent<Currency>().seekPlayer = true;
            }
        }
    }
    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(3);
        
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        int eliteSpawned = 0;
        for (int i = 0; i < eNumber; i++)
        {
            currentEnemies++;
            Object[] enemies = new Object[1];
            if (eliteSpawned<currentEliteMax)
                enemies = Resources.LoadAll("Elite/");
            else
                enemies = Resources.LoadAll("Enemies/");

            eliteSpawned++;
            Debug.Log(enemies);
            GameObject choosenEnemy = enemies[Random.Range(0, enemies.Length)] as GameObject;
            GameObject newEnemy = Instantiate(monsterSpawner);
            newEnemy.transform.position = new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70));
            newEnemy.GetComponent<MonsterSpawner>().monster = choosenEnemy;
            newEnemy.GetComponent<MonsterSpawner>().monster_hp = currentStage.max_enemy_hp_scaling;
            spawning = true;
            yield return new WaitForSeconds(0.1f);
        }
            //StartCoroutine(SpawnEnemies());
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStage = stages[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
