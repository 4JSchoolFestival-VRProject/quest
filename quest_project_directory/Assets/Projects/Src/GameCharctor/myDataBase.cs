using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NetwrokSystem;

static class myDataBase{

    static Player m_p;


    public static Player AgentPlayer()
    {
        
        if (DataBaseExists(m_p)) return m_p;
        else
        {
            Debug.Log("呼ばれたよ.");
            DisposeTable();
            return m_p;
        }
    }

    public static bool DataBaseExists(object o)
    {
        if(o == null) return false;
        else return true;
    }

    public static void DisposeTable()
    {
        m_p = new Player();
    }

    public static void QuerySet(Player p)
    {
        m_p = p;
    }

    public static void UpdateTable(Player p, bool isbase)
    {
        string[] temp = { "level:", "hp:", "mp:", "atk:", "def:" };
        string input = isbase ? "base:" : "status:";

        for (int i = 0; i < 5; i++)
        {
            input += temp[i] + p.Search(i).ToString() + ":";
        }
        QuerySet(p);
        ClientManager.singleton.Send(input);
    }

    public static void SetStatusToPlayer()
    {

    }

    public static void WhenMoveScene(Player p)
    {
        if (!(m_p.Name == null)) p.Name = m_p.Name;
        else return;
    }

    public static string StatusToString(string mod, string value)
    {
        return mod + value;
    }

    public static string StatusToString(string mod, int value)
    {
        return StatusToString(mod, value.ToString());
    }

    public static byte[] StringToByteA(string str)
    {
        byte[] b = System.Text.Encoding.ASCII.GetBytes(str);
        return b;
    }

    public static byte[] StringToByteA(int value)
    {
        byte[]b = StringToByteA(value.ToString());
        return b;
    }
}
