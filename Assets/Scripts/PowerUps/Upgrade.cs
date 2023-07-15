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
    public float speed = 0;
    public float jump_power = 0;
    public int jump_count = 0;
    public float recoil = 0f;
    public float boost_capacity = 0;
    public float boost_power = 0;
    public float boost_max_power = 0;
    public float boost_reload = 0;
    public float base_damage = 0;
    public float ray_load_time = 0;

    public int difficulty = 0;
    public int currency = 0;
    public int currency_drop = 0;
}
