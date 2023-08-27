using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Lightning",menuName = "Ability/Spell2")]
public class LightningSkill : Spell2
{
    public override void Activate()
    {
        base.Activate();
        //Debug.DrawRay(obje.transform.position+(Vector3.up*8f), Vector3.down);
        Debug.Log("YILDIRIM");
    }

    
}
