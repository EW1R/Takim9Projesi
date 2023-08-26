using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ring",menuName ="Magic/Ring")]
public class Ring : ScriptableObject
{
    public Spell1 leftClick;
    //Spell2 rigtClick;
    public Sprite ringImage;
    public string ringName;
    public bool isActive;
}
