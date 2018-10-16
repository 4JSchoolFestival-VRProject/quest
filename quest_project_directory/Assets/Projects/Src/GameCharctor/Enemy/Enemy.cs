using UnityEngine.UI;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour,GameCharacter {

    private StatusTable s;
    private HpRequest bar;
    private string namefields = "enemy";
    private bool flag;

    void start()
    {
       
        
    }

    public Enemy()
    {
        s = new StatusTable();
      //  eDebug();
    }

    void eDebug()
    {
        Debug.Log("int:" + Hp);
        Debug.Log("int:" + Mp);

    }

    public int Hp
    {
        get { return s.SearchStatusTable((int)StatusTable.Element.Hp); }
        set {
                int e = value;
                s.UpdateStatus((int)StatusTable.Element.Hp, e);
        }
    }

    public int Mp
    {
        get { return s.SearchStatusTable((int)StatusTable.Element.Mp); }
        set
        {
            int e = value;
            s.UpdateStatus((int)StatusTable.Element.Mp, e);
        }
    }

    public int KeyHp()
    {
        return (int)StatusTable.Element.Hp;
    }

    public int KeyMp()
    {
        return (int)StatusTable.Element.Mp;
    }

    public void HpBar(HpRequest h)
    {
        bar = h;
    }

    public void UpdateStatus(int key, int value)
    {
        s.UpdateStatus(key, value);
    }

    public int Search(int key)
    {
        return s.SearchStatusTable(key);
    }

    public bool GetFlag()
    {
        return flag;
    }

    public void SetFlag()
    {
        flag = true;
    }

    public void processBattleEvent()
    {
        processHpEvent(3);
    }

    public void processHpEvent(int damage)
    {
        UpdateStatus(KeyHp(),  Hp - damage);
        bar.Request(Hp);
        if( Hp <= 0) s.F_HP = true;
   
        
    }

    public void processMpEvent(int charge)
    {
        if ( Mp >= 0) return;
        UpdateStatus(KeyMp(), Mp - charge);

    }

    public void processLevelEvent(){ }
}
