using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

    Player player;
    Text tex;
	// Use this for initialization
	void Start () {
        tex = GetComponent<Text>();
        player = myDataBase.AgentPlayer();
        tex.text = player.Name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
