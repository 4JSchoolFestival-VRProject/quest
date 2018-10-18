using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, GameCharacter
{
    
    private string namefield;
    private static StatusTable s;

    void Start()
    {
        Debug.Log("Start: Player");
        s = GetComponent<StatusTable>();
        namefield = "player";
        UpdateStatus(1, 40);
        UpdateTable();
        PlayerLevel.flag = false;
        playerMp.flag = false;
    }

    public string Name
    {
        get{ return namefield; }
        set { namefield = value; }
    }

    public void UpdateStatus(int key, int value)
    {
        s.UpdateStatus(key, value);
        UpdateTable();
    }

    public int Search(int key)
    {
        return s.SearchStatusTable(key);
    }

    public void UpdateTable()
    {
        Debug.Log("update");
        myDataBase.UpdateTable(this);
    }

    public void processHpEvent(int damage)
    {
        Debug.Log(Search(1));
        int hp = Search(1);
        hp -= damage;
        if (hp < 0) hp = 0;
        UpdateStatus(1, hp);
    }

    public void processMpEvent(int charge)
    { }

    public void processBattleEvent()
    { }

    public void processLevelEvent()
    { }
}
