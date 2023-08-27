using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public Spell1 spell;
    public Ring instigator;
    //public float projectileLifeTime=6f;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(instigator.leftClick.damage);
            isDone = true;
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(instigator.leftClick.damage);
            isDone = true;
        }
    }


}
