using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour {
    Player player;
    Text tex;
    // Use this for initialization
    void Start()
    {
        tex = GetComponent<Text>();
        player = myDataBase.AgentPlayer();
        string la = "Lv: " + player.Search(0);
        tex.text = la;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
