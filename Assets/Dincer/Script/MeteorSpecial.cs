using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meteor", menuName = "Ability/Meteor")]
public class MeteorSpecial : Spell2
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("Meteor");
    }
}
