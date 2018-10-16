using UnityEngine;
using System;

public class StatusTable{
    public enum Element
    {
        Level, Hp, Mp, Atk, Def
    }
    private string name;
    private int[] status;
    private readonly int[] init_status = { 1, 20, 6, 8, 8 };
    private bool Flag_Hp;

    public StatusTable()
    {
        Flag_Hp = true;
        CreateStatusTable();
    }

    public bool F_HP
    {
        get { return Flag_Hp; }
        set { Flag_Hp = value; }
    }

    private void CreateStatusTable()
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
