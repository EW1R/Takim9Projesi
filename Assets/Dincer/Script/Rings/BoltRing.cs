using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoltRing", menuName = "Magic/BoltRing")]
public class BoltRing : ScriptableObject
{
    public Spell1 leftClick;
    public LightningSkill rightClick;
    //Spell2 rigtClick;
    public Sprite ringImage;
    public string ringName;
    public bool isActive;
    public List<GameObject> projectileList;

}
