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
            UseSpell1();
        }

        if (Input.GetMouseButton(1))
        {
            currentRing.rightClick.SetIndicator();
            currentRing.rightClick.ControlIndicator();
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            currentRing.rightClick.EndIndicate();
            currentRing.rightClick.Activate();
        }

        

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
            GameObject projectile = ProjectilePool(currentRing.projectileList);
            lastTimeSinceAttack = 0;

            projectile.transform.position = handPos.position;
            projectile.transform.localRotation = Quaternion.Euler(90,0,0);
            projectile.SetActive(true);

            projectile.GetComponent<Rigidbody>().velocity =Camera.main.transform.forward * currentRing.leftClick.projectileSpeed;

            anim.SetTrigger("isAttacking");//anim

        }


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
