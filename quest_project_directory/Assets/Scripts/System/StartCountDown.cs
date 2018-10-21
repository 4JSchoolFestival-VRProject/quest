using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Custom
{
    public class StartCountDown : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private Text text;

        public Action GameStartAction;

        private void Awake()
        {
            GameManager.startCountDown = this;
        }

        public void CountDown()
        {
            canvas.SetActive(true);
            StartCoroutine(_CountDown());
        }

        private IEnumerator _CountDown()
        {
            for (int n = 3; n > 0; n--)
            {
                text.text = n.ToString();
                yield return new WaitForSeconds(1.0f);
            }
            text.text = "Fight!";
            GameStartAction();
            yield return new WaitForSeconds(1.0f);
            canvas.SetActive(false);
            yield break;
        }

        public void CountDown(int stageNum)
        {
            GameStartAction = null;
            canvas.SetActive(true);
            StartCoroutine(_CountDown(stageNum));
        }

        private IEnumerator _CountDown(int stageNum)
        {
            text.text = "Stage " + (stageNum + 1).ToString();
            yield return new WaitForSeconds(2.0f);
            for (int n = 3; n > 0; n--)
            {
                text.text = n.ToString();
                yield return new WaitForSeconds(1.0f);
            }
            text.text = "Fight!";
            GameStartAction();
            yield return new WaitForSeconds(1.0f);
            canvas.SetActive(false);
            yield break;
        }
    }
}