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
