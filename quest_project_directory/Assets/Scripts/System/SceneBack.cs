using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBack : MonoBehaviour {
    public string scene;
    private static bool scene_back;
    public static bool F_Scene { set { scene_back = value; }}

    void Start () {
        scene_back = false;
		
	}

	void Update () {
        if (Input.GetKey(KeyCode.Space) | scene_back)
        {
            Cursor.visible = false;
            SceneManager.LoadScene(scene);

        }
    }
}
