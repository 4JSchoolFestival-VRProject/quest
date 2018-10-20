using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerSword : MonoBehaviour
    {
        private AudioSource m_AudioSource;

        private float m_CoolTime = 0;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (m_CoolTime > 0)
            {
                m_CoolTime -= Time.deltaTime;
                if (m_CoolTime < 0) m_CoolTime = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
           // if (m_CoolTime > 0) return;
            switch (other.tag)
            {
                case "Enemy":
                    EnemyController enemy = other.GetComponent<EnemyController>();
                    enemy.AddDamage(PlayerController.singleton.status.parameters.atk);
                    m_AudioSource.PlayOneShot(AudioController.singleton.SEList[1]);
                    m_CoolTime += 0.5f;
                    break;
                case "EnemyWeapon":
                    m_CoolTime += 0.5f;
                    break;
            }
        }
    }
}