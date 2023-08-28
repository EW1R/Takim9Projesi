using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireRing",menuName ="Magic/FireRing")]
public class FireRing : ScriptableObject
{
    public Spell1 leftClick;
    public Spell2 rightClick;
    //Spell2 rigtClick;
    public Sprite ringImage;
    public string ringName;
    public bool isActive;
    public List<GameObject> projectileList;

}
