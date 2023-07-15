using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeMachine : MonoBehaviour
{
    public GameObject upgrade;
    public GameObject screen;
    public Upgrade[] upg = new Upgrade[3];
    // Start is called before the first frame update
    void Start()
    {
        GenerateUpgrade();
    }
    public void GenerateUpgrade()
    {
        for(int i = 0; i < 3; i++)
        {
            Object[] b = new Object[1];
            if (Random.value>0.2f)
                b = Resources.LoadAll("Upgrades/Common");
            if(Random.value > 0.5f)
                b = Resources.LoadAll("Upgrades/Common");

            Upgrade bb = b[Random.Range(0, b.Length-1)] as Upgrade;

            GameObject newUpgrade = Instantiate(upgrade);
            newUpgrade.transform.parent = screen.transform;
            newUpgrade.transform.localScale = Vector3.one;
            newUpgrade.transform.localPosition = Vector3.zero;
            newUpgrade.transform.rotation = screen.transform.rotation;
            newUpgrade.transform.Find("Name").GetComponent<Text>().text = bb.name;
            newUpgrade.transform.Find("Desc").GetComponent<Text>().text = bb.description;
            upg[i] = bb;
            
        }
    }
    void UpgradePlayer(int w)
    {
        Upgrade bb = upg[w];

        PlayerStats.instance.health *= bb.health / 10;
        PlayerStats.instance.speed *= bb.speed / 10;
        PlayerStats.instance.jump_power *= bb.jump_power / 10;
        PlayerStats.instance.jump_count += bb.jump_count;
        PlayerStats.instance.boost_capacity *= bb.boost_capacity / 10;
        PlayerStats.instance.boost_power *= bb.boost_power / 10;
        PlayerStats.instance.boost_max_power *= bb.boost_max_power / 10;
        PlayerStats.instance.boost_reload *= bb.boost_reload / 10;
        PlayerStats.instance.base_damage *= bb.base_damage / 10;
        PlayerStats.instance.ray_load_time *= bb.ray_load_time / 10;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
