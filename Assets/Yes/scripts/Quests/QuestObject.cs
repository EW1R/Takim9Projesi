using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    private bool inTrigger;

    public List<int> avaliableQuestIds = new List<int>();
    public List <int> recievableQuestIds= new List<int>();



    private void Update()
    {
        if(inTrigger)
        {

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {   
             inTrigger= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger= false;
        }
    }

}
