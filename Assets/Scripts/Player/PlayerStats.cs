using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //To jest skrypt globalny
    //Mo¿na odwo³aæ siê do niego u¿ywaj¹c PlayerStats.instance
    public static PlayerStats instance;

    private void Awake()
    {
        instance = this; 
    }
    //Tutaj znajduj¹ siê wszystkie zmienne jakie bêdziemy nadpisywaæ upgradeami.
    public int health = 3;
    public float speed = 5;
    public float jump_power = 5;
    public int jump_count = 2;
    public float recoil = 0.1f;
    public float boost_capacity = 2;
    public float boost_power = 25;
    public float boost_max_power = 100;
    public float boost_reload = 1;
    public float base_damage = 3;
    public float ray_load_time = 1;
    public float shoot_delay = 0.1f;
    public int difficulty = 0;
    public int currency = 0;
    public int currency_drop = 10;
}
