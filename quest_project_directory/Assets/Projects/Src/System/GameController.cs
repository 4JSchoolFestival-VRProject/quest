using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    static Player m_p;
    public Text label_name, label_hp;
    public static string name, hp;

	// Use this for initialization
	void Start () {
        m_p = myDataBase.AgentPlayer();
        //  myDataBase.WhenMoveScene(m_p);
        if (m_p != null)
        {
         //   Debug.Log("int:" + m_p.Search(1));

        }
        else
        {
            Debug.LogWarning("set Script Player!");
        }
        //Debug.Log("name:" + m_p.Name);
        
        UpdateLabel();
		
	}
	
	// Update is called once per frame
	void Update () {
        label_name.text = name;
        label_hp.text = hp;

	}

    public static void UpdateTable(Player p)
    {
        m_p = p;
        UpdateLabel();
    }

    public static void UpdateLabel()
    {
        name = myDataBase.StatusToString("Name :", m_p.Name);
        hp = myDataBase.StatusToString("HP :", m_p.Search(1));
    }
}
