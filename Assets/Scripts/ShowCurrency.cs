using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowCurrency : MonoBehaviour
{
    private Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = PlayerStats.instance.currency.ToString();
    }
}
