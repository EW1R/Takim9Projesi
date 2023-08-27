using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public enum QuestProgress {Closed, Open, Accepted, Complete, Done }    //public enum PlayerChoice {King, Pesant } 2. yolu yapacak olursak


    public string title;            //Quest baþlýðý
    public int id;                  //Quest sýra numarasý
    public QuestProgress progress;  //Questin hangi aþamada olduðu bilgisi
    public string description;      // Questin tam metni
    public string congratulations;  // Quest tamamlama metni
    public string summary;          //Quest ne istiyor kýsaca özeti
    public int nextQuest;           //Sýradaki questin idsi


    public Vector2 questDirection;  //Questin konumu


    public string questObjective;           //Quest beklentisi
    public int questObjectiveCount;         //quest için tamamlanan adým sayýsý
    public int questObjectiveRequirements; //Questin tamamlanmasý için gereken adým sayýsý

    public string questItem; //questin tamamlanmasý ile alýnacak item
}
