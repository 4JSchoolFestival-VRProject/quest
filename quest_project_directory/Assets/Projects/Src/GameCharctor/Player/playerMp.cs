using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMp : MonoBehaviour
{

    Text tex;
    Slider sl;
    Player player;
    int mp;
    int maxmp;

    void Start()
    {
        tex = gameObject.transform.Find("Text").GetComponent<Text>();
        sl = GetComponent<Slider>();
        player = myDataBase.AgentPlayer();
        maxmp = player.Search(2);
        sl.maxValue = maxmp;
    }

    // Update is called once per frame
    void Update()
    {
        player = myDataBase.AgentPlayer();
        mp = player.Search(2);
        sl.value = mp;
        tex.text = myDataBase.StatusToString(mp.ToString(), myDataBase.StatusToString("/", maxmp));
    }
}
