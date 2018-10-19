using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : UIController
{
    private bool isPushed;

    protected override void Awake()
    {
        base.Awake();
        ResetGame();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            OnClickStartButton();
    }

    public void OnClickStartButton()
    {
        if (isPushed) return;
        isPushed = true;
        SceneManager.LoadScene("Encount");
    }

    private void ResetGame()
    {
        OVRManager.display.displayFrequency = 72f;
    }
}