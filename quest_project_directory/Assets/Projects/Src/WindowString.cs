using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class WindowString : MonoBehaviour {

    Text tex;
    float settime = 4.0f;
    float TimeCount;
    private int count;
    string filepath;
    StreamReader streamReader;

    void Start () {
        tex = GetComponent<Text>();
        tex.text = "sssssssss";
       filepath = Application.temporaryCachePath + "/unity_tex 2.txt";
        tex.text = "ssssssaaaaas";
        streamReader = new StreamReader(filepath, Encoding.UTF8);
        tex.text = "ssssssss\\\\s";
        TimeCount = settime;
    }

    
	
	// Update is called once per frame
	void Update () {
        TimeCount -= Time.deltaTime;
        if(TimeCount <= 0 && !streamReader.EndOfStream)
        {
            tex.text = streamReader.ReadLine();
            tex.text += "\n";
            TimeCount = settime;
           
        }
        
	}
    
    
}
