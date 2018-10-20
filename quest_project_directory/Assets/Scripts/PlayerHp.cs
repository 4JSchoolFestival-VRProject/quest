using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {

    Text tex;
    Slider sl;
    Player player;
    int hp;
    int maxhp;

	void Start () {
        tex = gameObject.transform.Find("Text").GetComponent<Text>();
        sl = GetComponent<Slider>();
        player = myDataBase.AgentPlayer();
        maxhp = player.Search(1);
        sl.maxValue = maxhp;
	}
	
	// Update is called once per frame
	void Update () {
        player = myDataBase.AgentPlayer();
        hp = player.Search(1);
        sl.value = hp;
        tex.text = myDataBase.StatusToString(hp.ToString(), myDataBase.StatusToString("/", maxhp));
	}
}
