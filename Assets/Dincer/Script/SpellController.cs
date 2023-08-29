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
    private float lastTimeSinceAbility = Mathf.Infinity;
    [SerializeField]
    private Animator anim;
    private bool isAttacking1;
    private bool isAttacking2;







    private void Start()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();
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
            if (lastTimeSinceAttack >= currentRing.leftClick.timeBetweenAttacks)
            {
                lastTimeSinceAttack = 0;
                isAttacking1 = true;
            }
            

            
        }

        if (lastTimeSinceAbility >= currentRing.rightClick.cooldown)
        {
            if (Input.GetMouseButton(1))
            {
               
                    currentRing.rightClick.ControlIndicator();

                
            }

        
            if (Input.GetMouseButtonUp(1))
            {


                isAttacking2 = true;
                lastTimeSinceAbility = 0;
                currentRing.rightClick.EndIndicate();
                currentRing.rightClick.Activate();

            }
        }


        Debug.Log(lastTimeSinceAbility + "ATTTTT");

        SetBools();
        CheckTimers();
    }

 
    private void CheckTimers()
    {
        lastTimeSinceAttack += Time.deltaTime;
        lastTimeSinceAbility+=Time.deltaTime;
    }

    private void UseSpell1()
    {
        GameObject projectile = ProjectilePool(currentRing.projectileList);
        projectile.transform.position = handPos.position;
        projectile.transform.localRotation = Quaternion.Euler(62, 30, 0);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * currentRing.leftClick.projectileSpeed;
        isAttacking1 = false;
    
                //            anim.SetTrigger("isAttacking");//anim

    }

    private void SetBools()
    {
        anim.SetBool("isAttacking1", isAttacking1);
        anim.SetBool("isAttacking2", isAttacking2);
    }

    public void EndAttack2()
    {
        isAttacking2 = false;
    }
    private GameObject ProjectilePool(List<GameObject> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != null && !list[i].activeSelf )
            {
                return list[i];
            }
        }

        list.Add(Instantiate(currentRing.leftClick.projectile, handPos.position, Quaternion.identity));
        list[^1].GetComponent<Projectiles>().instigator = currentRing;
        return list[^1];

    }

    
  
}
