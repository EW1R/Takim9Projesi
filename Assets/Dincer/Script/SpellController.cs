using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{

    public Transform handPos;
    private Ring currentRing;

    List<GameObject> projectilePool = new List<GameObject>();

    private float lastTimeSinceAttack = Mathf.Infinity;
    private Animator anim;

    private float time;
    public bool isAttacking = false;

    private void Start()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();

        if (currentRing == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            UseSpell1();
        }
            


        time = currentRing.leftClick.timeBetweenAttacks;
        CheckTimers();
    }

    private void CheckTimers()
    {
        lastTimeSinceAttack += Time.deltaTime;
    }

    private void UseSpell1()
    {
        if (lastTimeSinceAttack >= currentRing.leftClick.timeBetweenAttacks)
        {
            GameObject projectile = ProjectilePool();
            lastTimeSinceAttack = 0;

            projectile.transform.position = handPos.position;
            projectile.transform.localRotation = Quaternion.Euler(0,0,0);
            projectile.SetActive(true);

            projectile.GetComponent<Rigidbody>().velocity =Camera.main.transform.forward * currentRing.leftClick.projectileSpeed;

            anim.SetTrigger("isAttacking");

        }


    }

    private GameObject ProjectilePool()
    {

        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (projectilePool[i] != null && !projectilePool[i].activeSelf )
            {
                return projectilePool[i];
            }
        }

        projectilePool.Add(Instantiate(currentRing.leftClick.projectile, handPos.position, Quaternion.identity));

        return projectilePool[^1];


       

    }

    
  
}
