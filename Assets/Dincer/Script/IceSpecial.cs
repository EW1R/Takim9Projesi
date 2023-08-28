using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ice", menuName = "Ability/Ice")]
public class IceSpecial : Spell2
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Ice");
    }
}
