using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, GameCharacter
{
    //public static Player singleton;
    public Camera centerEyeAnchor;

    private string namefield;
    private static StatusTable s;
    private PlayerMagica pm;

    void Awake()
    {

    }

    void Start()
    {
        Debug.Log("Start: Player");
        s = GetComponent<StatusTable>();
        namefield = "player";
        //UpdateStatus(1, 40, true);
        //UpdateTable(true);
        PlayerLevel.flag = false;
        playerMp.flag = false;
    }

    public string Name
    {
        get{ return namefield; }
        set { namefield = value; }
    }

    public bool MpZero()
    {
        bool b;
        return b = (Search(2) > 0) ?  true: false;

    }

    public bool HpZero()
    {
        bool b;
        return b = (Search(1) <= 0) ? true : false;
    }

    public void UpdateStatus(int key, int value, bool isbase)
    {
        s.UpdateStatus(key, value);
        UpdateTable(isbase);
    }

    public int Search(int key)
    {
        return s.SearchStatusTable(key);
    }

    public void UpdateTable(bool isbase)
    {
        Debug.Log("update");
        myDataBase.UpdateTable(this, isbase);
    }

    public void processHpEvent(int damage)
    {
       // Debug.Log(Search(1));
        int hp = Search(1) - damage;
        if (HpZero() && hp < 0) hp = 0;
        UpdateStatus(1, hp, false);
    }

    public void processMpEvent(int charge)
    {
        Debug.Log(Search(2));
        int mp;
        if (MpZero())
        {
            mp = 0;
            return;
        }
        mp = Search(2) - charge;
        UpdateStatus(2, mp, false);

    }

    public int processBattleEvent()
    {
        return Search(3);
    }

    public void processDefenceEvent(int atk, bool phisic)
    {
        int def_point;
        int ran = Random.Range(0, 4);
        def_point = phisic ? (int)(atk * 1.1) - Search(4) : (int)(atk * 0.9) - (int)(Search(4) * 0.8);
        processHpEvent(def_point + ran);
    }

    public void processLevelEvent()
    {
        /*
        int lv = Search(0) + 1;
        UpdateStatus(0, Search(0) + 1, false);
        for(int i = 1; i < 5; i++)
        {
            UpdateStatus(i, Search(i) + lv, true);
        }
        */
    }
}
