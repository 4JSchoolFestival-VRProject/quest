using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private Canvas menuCanvas;

    protected virtual void Awake()
    {
        menuCanvas = GetComponent<Canvas>();
    }

    protected virtual void Start()
    {
        menuCanvas.worldCamera = Player.singleton.centerEyeAnchor;
    }
}