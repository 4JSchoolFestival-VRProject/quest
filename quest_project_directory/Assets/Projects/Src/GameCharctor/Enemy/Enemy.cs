using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,GameCharacter {

    private StatusTable s;
    private HpRequest bar;
    private EnemyAnimator ani;
    private NavMeshAgent agent;
    private string namefields = "enemy";
    private bool flag;

    void Start()
    {
        s = new StatusTable();
        ani = GetComponent<EnemyAnimator>();
        agent = GetComponent<NavMeshAgent>();
        HpRequest.SetEnemy(this);
//        bar.EnemyHpInitialized(s.SearchStatusTable(1), s.SearchStatusTable(1));


    }

    public bool isZero()
    {
        return s.F_HP;
    }

    /*
    void eDebug()
    {
        Debug.Log("int:" + Hp);
        Debug.Log("int:" + Mp);

    }
    */
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
        if (Hp <= 0) Destroy(gameObject);
   
        
    }

    public void processMpEvent(int charge)
    {
        if ( Mp >= 0) return;
        UpdateStatus(KeyMp(), Mp - charge);

    }

    public void processLevelEvent(){ }
}
