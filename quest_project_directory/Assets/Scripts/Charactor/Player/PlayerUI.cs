using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Custom
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Text nameText;
        [SerializeField] private Text levelText;
        [SerializeField] private Text hpText;
        [SerializeField] private Text mpText;

        [SerializeField] private Slider hpSlider;
        [SerializeField] private Slider mpSlider;

        private void Start()
        {
            nameText.text = "VR勇者";
        }

        private void Update()
        {
            levelText.text = "Lv." + PlayerController.singleton.status.parameters.level.ToString();

            hpSlider.maxValue = PlayerController.singleton.status.maxParameters.hp;
            mpSlider.maxValue = PlayerController.singleton.status.maxParameters.mp;
            hpSlider.value = PlayerController.singleton.status.parameters.hp;
            mpSlider.value = PlayerController.singleton.status.parameters.mp;
            hpText.text = hpSlider.value.ToString() + "/" + hpSlider.maxValue.ToString();
            mpText.text = mpSlider.value.ToString() + "/" + mpSlider.maxValue.ToString();
        }
    }
}