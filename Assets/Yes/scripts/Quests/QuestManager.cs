using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();           //T�m questleri tutan liste
    public List<Quest> currentQuestList = new List<Quest>();    //Al�nm�� Questlerin listesi


    private void Awake()
    {
        if(questManager == null)
        {
            questManager = this;
        }
        else if(questManager!= this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

}
