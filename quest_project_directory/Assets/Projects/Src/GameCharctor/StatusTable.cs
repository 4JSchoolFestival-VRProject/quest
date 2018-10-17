using UnityEngine;
using System;

public class StatusTable : MonoBehaviour{
    public enum Element
    {
        Level, Hp, Mp, Atk, Def
    }
    private string name;
    private int[] status;
    private readonly int[] init_status = { 1, 20, 6, 8, 8 };
    private bool Flag_Hp;


    void Awake()
    {
        status = init_status;
        Debug.Log("Awake; status" + status[0]);
    }

    void Start()
    {
        Flag_Hp = true;
    }

    public StatusTable()
    {
        CreateStatusTable();
    }

    public bool F_HP
    {
        get { return Flag_Hp; }
        set { Flag_Hp = value; }
    }

    public void CreateStatusTable()
    {
        status = new int[5];
        foreach (Element e in Enum.GetValues(typeof(Element)))
        {
            status[(int)e] = init_status[(int)e];
        }

    }

    public int SearchStatusTable(int key)
    {
        return status[key];

    }

    public void UpdateStatus(int key, int value)
    {
        status[key] = value;
    }

    protected virtual void UpdateTable()
    {

    }
}
