using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest1
{
    public string questName;
    public string description;
    public bool isCompleted;
}

public class QuestManager2 : MonoBehaviour
{
    public List<Quest1> quests = new List<Quest1>();

    public void CompleteQuest(string questName)
    {
        Quest1 quest = quests.Find(q => q.questName == questName);
        if (quest != null)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + quest.questName);
        }
    }
}