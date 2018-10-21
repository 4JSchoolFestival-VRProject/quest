using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadSceneAsync("Title");
        yield break;
    }
}