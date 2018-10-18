using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public SceneObject scene;
    private Player p;
    [SerializeField]
    FadeImage img = null;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        p = myDataBase.AgentPlayer();

        if (p.HpZero())
        {
            SceneManager.LoadScene(scene);

        }
		
	}
    /*
    private IEnumerator Load(SceneObject scene)
    {
        img = GameObject.FindObjectOfType<FadeImage>();
        for (int i = 1; i < 101; i++)
        {
            if(img.Range >= 1){
                break;
            }
            yield return new WaitForSeconds(0.1f);
            img.Range += (float)(i * 0.001);
        }
        SceneManager.LoadScene(scene);
    }
    */
}
