using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamdisappear : MonoBehaviour
{
    float w = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        w -= 0.001f;
        w = Mathf.Clamp(w, 0, 1);
        GetComponent<LineRenderer>().widthMultiplier = w;
    }
}
