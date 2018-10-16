using System.Collections;
using UnityEngine;

public class SlashController : MonoBehaviour {


    [SerializeField]
    private Texture2D cursor;
    // Use this for initialization
    void Start() {
        Cursor.visible = true;
        Cursor.SetCursor(cursor, 
            new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
	}

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
