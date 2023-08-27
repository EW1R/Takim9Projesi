using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();           //Tüm questleri tutan liste
    public List<Quest> currentQuestList = new List<Quest>();    //Alýnmýþ Questlerin listesi
    public List<Quest> receivableQuestsIDs= new List<Quest>();  //Alýnabilir QUest Listesi

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

    public void QuestRequest(QuestObject NPCQuestObject)
    {
        //Alýnabilir görev
        if(NPCQuestObject.avaliableQuestIds.Count > 0) 
        { 
            for(int i = 0; i<questList.Count; i++) 
            {
                for(int j =0; j < NPCQuestObject.avaliableQuestIds.Count; j++) 
                {
                    if (questList[i].id == NPCQuestObject.avaliableQuestIds[j] && questList[i].progress == Quest.QuestProgress.Open)
                    {
                        Debug.Log("Quest ID: " + NPCQuestObject.avaliableQuestIds[j]+" " + questList[i].progress);

                        AcceptQuest(NPCQuestObject.avaliableQuestIds[j]);
                    }
                }
            }
        }
        //Aktif görev
        for(int j =0; j < currentQuestList.Count; j++)
        {
            for (int i = 0; i < NPCQuestObject.recievableQuestIds.Count; i++)
            {
                if (currentQuestList[j].id == NPCQuestObject.recievableQuestIds[i] && currentQuestList[j].progress == Quest.QuestProgress.Accepted || currentQuestList[j].progress == Quest.QuestProgress.Complete) ;
                {
                    //quest ui
                    Debug.Log("Quest ID: " + NPCQuestObject.recievableQuestIds[i] + " is  " + currentQuestList[j].progress);

                    CompleteQuest(NPCQuestObject.recievableQuestIds[i]);
                }
            }
        }
    }


    public bool RequestOpenQuest(int questID)//mevcut alýnabilir quest çekme
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

    public bool RequestAcceptedQuest(int questID) //Mevcut alýnmýþ quest çekme
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

    public bool RequestCompleteQuest(int questID) //Tamamlanmýþ quest çekme
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.Complete)
            {
                return true;
            }
        }
        return false;
    }



    public void IncrementQuestStep(string questObjective, int questStepsCount) //Quest progress sistemi
    {
        for(int i = 0; i < currentQuestList.Count; i++) 
        {
            if (currentQuestList[i].questObjective == questObjective && currentQuestList[i].progress == Quest.QuestProgress.Accepted)
            {
                currentQuestList[i].questObjectiveCount += questStepsCount;
            }

            if (currentQuestList[i].questObjectiveCount >= currentQuestList[i].questObjectiveRequirements && currentQuestList[i].progress == Quest.QuestProgress.Accepted)
            {
                currentQuestList[i].progress = Quest.QuestProgress.Complete;
            }
        }
    }


    public void AcceptQuest(int questID)//Questi kabul etme
    {
        for(int i = 0; i<= questList.Count; i++) 
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.Open)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.Accepted;
            }
        }

    }

    public void CompleteQuest(int questID)
    {
        for(int i=0; i< currentQuestList.Count; i++) 
        {
            currentQuestList[i].progress-= Quest.QuestProgress.Done;
            currentQuestList.Remove(currentQuestList[i]);
        }
    }
}
