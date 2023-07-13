using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealthText : MonoBehaviour
{
    public TMP_Text health, quote_ref;
    private string av_quote = "";
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<TMP_Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void ShowHealth()
    {
        av_quote = "";

        for (int i = 0; i < player.health; i++)
        {
            if(i>quote_ref.text.Length-1)
                quote_ref.text += "\n"+quote_ref.text;
            av_quote += quote_ref.text[i];
        }
        health.text = av_quote;
    }
    // Update is called once per frame
    void Update()
    {
        ShowHealth();
    }
}
