using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChallengeMachine : MonoBehaviour
{
    public int diff = 0;
    private bool isActive = false;
    [SerializeField] private GameObject screen;
    [SerializeField] private Text diffNow, diffNext;
    [SerializeField] private List<string> stageNames;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            isActive = true;        
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        screen.SetActive(isActive);
        diff = PlayerStats.instance.difficulty;

        if(isActive)
        {
            if (diff <= stageNames.Count)
            {
                StageManager.instance.currentStage = StageManager.instance.stages[PlayerStats.instance.difficulty];
                diffNow.text = StageManager.instance.currentStage.name;
                diffNext.text = StageManager.instance.stages[PlayerStats.instance.difficulty + 1].name;
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    PlayerStats.instance.difficulty++;
                }
            }
            else
            {
                diffNow.text = stageNames[stageNames.Count - 1];
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                StageManager.instance.LoadLevel();
            }
        }
    }
}
