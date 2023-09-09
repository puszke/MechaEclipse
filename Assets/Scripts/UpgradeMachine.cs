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
        foreach(GameObject a in GameObject.FindGameObjectsWithTag("Upgrade"))
        {
            Destroy(a);
        }
        for(int i = 0; i < 3; i++)
        {
            Object[] b = new Object[1];
            if (Random.value>0.2f)
                b = Resources.LoadAll("Upgrades/Rare");
            if (Random.value > 0.5f)
                b = Resources.LoadAll("Upgrades/Uncommon");
            else
                b = Resources.LoadAll("Upgrades/Common");

            Upgrade bb = b[Random.Range(0, b.Length)] as Upgrade;

            GameObject newUpgrade = Instantiate(upgrade);
            newUpgrade.transform.parent = screen.transform;
            newUpgrade.transform.localScale = Vector3.one;
            newUpgrade.transform.localPosition = Vector3.zero;
            newUpgrade.transform.rotation = screen.transform.rotation;
            newUpgrade.transform.Find("Name").GetComponent<Text>().text = bb.name;
            newUpgrade.transform.Find("Desc").GetComponent<Text>().text = bb.description;
            newUpgrade.transform.Find("_txt").GetComponent<Image>().sprite = bb.img;
            upg[i] = bb;
            
        }
    }
    void UpgradePlayer(int w)
    {
        Upgrade bb = upg[w];

        PlayerStats.instance.health += bb.health;
        PlayerStats.instance.speed *= bb.speed / 100;
        PlayerStats.instance.jump_power *= bb.jump_power / 100;
        PlayerStats.instance.jump_count += bb.jump_count;
        PlayerStats.instance.boost_capacity *= bb.boost_capacity / 100;
        PlayerStats.instance.boost_power *= bb.boost_power / 100;
        PlayerStats.instance.boost_max_power *= bb.boost_max_power / 100;
        PlayerStats.instance.boost_reload *= bb.boost_reload / 100;
        PlayerStats.instance.base_damage *= bb.base_damage / 100;
        PlayerStats.instance.ray_load_time *= bb.ray_load_time / 100;
        PlayerStats.instance.shoot_delay *= bb.shoot_delay / 100;
    }

    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            UpgradePlayer(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            UpgradePlayer(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            UpgradePlayer(2);
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        if(Input.GetKeyDown(KeyCode.R))
        {
            GenerateUpgrade();
        }
    }
}
