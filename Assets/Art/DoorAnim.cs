using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
   public Animator leftDoor;
   public Animator rightDoor;

   public bool openTrigger;
   public bool closeTrigger;
 
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
        if (openTrigger)
        {
            leftDoor.Play("Open",0,0.0f);
            rightDoor.Play("Open",0,0.0f);
            gameObject.SetActive(false);
        }
        else if(closeTrigger)
        {
             leftDoor.Play("Close",0,0.0f);
            rightDoor.Play("Close",0,0.0f);
            gameObject.SetActive(false);
        }
    }
      
  }


}
