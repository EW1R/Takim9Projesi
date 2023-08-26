using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    private Ring currentRing;

    private GameObject projectile;

    private void Start()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();
    }

    private void Update()
    {
        currentRing = GetComponent<Rings>().GetCurrentRing();

        if (currentRing==null)
        {
            return;
        }

        UseSpell1();




    }

    private void UseSpell1()
    {
        List<GameObject> bullets = new List<GameObject>();

        for (int i = 0; i < bullets.Count; i++)
        {
            projectile = bullets[i];
        }
    }
}
