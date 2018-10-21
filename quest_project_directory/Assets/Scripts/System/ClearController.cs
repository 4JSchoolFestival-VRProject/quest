using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearController : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync("Title");
        yield break;
    }
}