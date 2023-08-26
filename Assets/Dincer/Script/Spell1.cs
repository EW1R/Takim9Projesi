using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spell", menuName = "Magic/Spell")]

public class Spell1 : ScriptableObject
{
    public string spellName;
    public float projectileSpeed;
    public ParticleSystem vfx;
    public float damage;
    public AnimatorOverrideController animation;
    public GameObject projectile;
    public float timeBetweenAttacks;
}
