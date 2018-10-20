using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Custom
{
    public class EnemyUI : MonoBehaviour
    {
        private EnemyController m_Controller;

        [SerializeField] private Slider hpSlider;

        private void Awake()
        {
            m_Controller = GetComponentInParent<EnemyController>();
        }

        private void Start()
        {
            hpSlider.minValue = 0;
        }

        private void Update()
        {
            hpSlider.maxValue = m_Controller.status.maxParameters.hp;
            hpSlider.value = m_Controller.status.parameters.hp;
        }
    }
}