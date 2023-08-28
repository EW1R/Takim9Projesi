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
            isAttacking1 = true;
        }
        

        if (Input.GetMouseButton(1))
        {
            print("Mouse");
            isAttacking2 = true;
            currentRing.rightClick.ControlIndicator();  
            
            print("MouseGecti");

        }
        if (Input.GetMouseButtonUp(1))
        {
            isAttacking2 = false;
            currentRing.rightClick.EndIndicate();
            currentRing.rightClick.Activate();
        }


        SetBools();
        CheckTimers();
    }

    private void CheckTimers()
    {
        lastTimeSinceAttack += Time.deltaTime;
    }

    private void UseSpell1()
    {
        if (isAttacking1)
        {

            if (lastTimeSinceAttack >= currentRing.leftClick.timeBetweenAttacks)
            {

                GameObject projectile = ProjectilePool(currentRing.projectileList);
                lastTimeSinceAttack = 0;

                projectile.transform.position = handPos.position;
                projectile.transform.localRotation = Quaternion.Euler(62, 30, 0);
                projectile.SetActive(true);

                projectile.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * currentRing.leftClick.projectileSpeed;

                //            anim.SetTrigger("isAttacking");//anim

            }
            isAttacking1 = false;
        }


    }


    private void SetBools()
    {
        anim.SetBool("isAttacking1", isAttacking1);
        anim.SetBool("isAttacking2", isAttacking2);
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
