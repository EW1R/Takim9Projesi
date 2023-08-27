using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = 3;
        time = time=-Time.deltaTime;
        print(time);
    }
}
