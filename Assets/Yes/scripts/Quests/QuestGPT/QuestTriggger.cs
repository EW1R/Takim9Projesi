using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggger : MonoBehaviour
{
    public string questName;
    public QuestManager2 questManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questManager.CompleteQuest(questName);
            Destroy(gameObject);
        }
    }
}
