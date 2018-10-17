using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {
    Player player;
    Text tex;
    public static bool flag;
    // Use this for initialization
    void Start()
    {
        Debug.Log("levelです");
        tex = GetComponent<Text>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (flag) return;
        player = myDataBase.AgentPlayer();
        string la = "Lv: " + player.Search(0);
        tex.text = la;
    }
}
