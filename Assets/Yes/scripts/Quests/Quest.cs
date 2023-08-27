using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public enum QuestProgress {Closed, Open, Accepted, Complete, Done }    //public enum PlayerChoice {King, Pesant } 2. yolu yapacak olursak


    public string title;            //Quest ba�l���
    public int id;                  //Quest s�ra numaras�
    public QuestProgress progress;  //Questin hangi a�amada oldu�u bilgisi
    public string description;      // Questin tam metni
    public string congratulations;  // Quest tamamlama metni
    public string summary;          //Quest ne istiyor k�saca �zeti
    public int nextQuest;           //S�radaki questin idsi


    public Vector2 questDirection;  //Questin konumu


    public string questObjective;           //Quest beklentisi
    public int questObjectiveCount;         //quest i�in tamamlanan ad�m say�s�
    public int questObjectiveRequirements; //Questin tamamlanmas� i�in gereken ad�m say�s�

    public string questItem; //questin tamamlanmas� ile al�nacak item
}
