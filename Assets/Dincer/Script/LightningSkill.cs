using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Lightning",menuName = "Ability/Spell2")]
public class LightningSkill : Spell2
{
    public override void Activate()
    {
        base.Activate();
        Debug.Log("YILDIRIM");

    }

}
