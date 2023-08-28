using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceRing", menuName = "Magic/IceRing")]
public class IceRing : ScriptableObject
{
    public Spell1 leftClick;
    public IceSpecial rightClick;
    //Spell2 rigtClick;
    public Sprite ringImage;
    public string ringName;
    public bool isActive;
    public List<GameObject> projectileList;

}