using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public Spell1 spell;


    float currentTime = 0;

    bool isDone = false;
    
    private void Start()
    {
        currentTime = 0;
        
    }


    void Update()
    {
        if (currentTime >= spell.projectileLifeTime)
        {
            gameObject.SetActive(false);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            isDone = true;
        }
        if (gameObject.activeSelf)
        {
            currentTime += Time.deltaTime;

        }
        
          

        if (isDone)
        {
            currentTime = 0;
            isDone = false;
        }
        
    }


}
