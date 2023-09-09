using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Upgrade", menuName = "Upgrade")]
public class Upgrade : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite img;

    public bool advanced = false;
    public Component advancedComponent;

    public int health = 0;
    public float speed = 100;
    public float jump_power = 100;
    public int jump_count = 0;
    public float recoil = 100f;
    public float boost_capacity = 100;
    public float boost_power = 100;
    public float boost_max_power = 100;
    public float boost_reload = 100;
    public float base_damage = 100;
    public float ray_load_time = 100;
    public float shoot_delay = 100;
    public int difficulty = 100;
    public int currency = 100;
    public int currency_drop = 100;
}
