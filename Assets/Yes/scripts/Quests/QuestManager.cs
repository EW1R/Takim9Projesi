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

    public bool RequestOpenQuest(int questID)//mevcut al�nabilir quest �ekme
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.Open)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestAcceptedQuest(int questID) //Mevcut al�nm�� quest �ekme
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.Accepted)
            {
                return true;
            }
        }
        return false;
    }

    public void IncrementQuestStep(string questObjective, int questStepsCount)
    {
        for(int i = 0; i < currentQuestList.Count; i++) 
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.Accepted)
            {
                currentQuestList[i].questObjectiveCount += questStepsCount;
            }

            if (currentQuestList[i].questObjective >= questObjective && currentQuestList[i].questObjectiveRequirements == Quest.QuestProgress.Accepted)
            {
                currentQuestList[i].progress = Quest.QuestProgress.Complete;
            }
        }
    }
}
