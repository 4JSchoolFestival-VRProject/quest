using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, GameCharacter
{
    
    private string namefield;
    private static StatusTable s;

    void start()
    {
        Debug.Log("Start: Player");
    }

    public Player()
    {
        if (namefield == null)
        {
            namefield = "player";
        }
        s = new StatusTable();
        UpdateTable();
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
        myDataBase.UpdateTable(this);
    }

    public void processHpEvent(int damage)
    {
        int hp = Search(1);
        hp -= damage;
        if (hp < 0) hp = 0;
        UpdateStatus(1, hp);
    }

    public void processMpEvent(int charge) { }
    public void processBattleEvent() { }
    public void processLevelEvent() { }
}
