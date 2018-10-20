using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyWeapon : MonoBehaviour
    {
        private EnemyController m_Controller;
        private AudioSource m_AudioSource;

        public bool isAttacking;
        public bool isAttacked;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
            m_Controller = GetComponentInParent<EnemyController>();
            Debug.Log(m_Controller);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isAttacking || isAttacked) return;

            switch (other.tag)
            {
                case "Player":
                    isAttacking = false;
                    isAttacked = true;
                    Debug.Log("攻撃ヒット");
                    m_AudioSource.PlayOneShot(AudioController.singleton.SEList[3]);
                    PlayerController.singleton.AddDamage(m_Controller.status.parameters.atk);
                    break;
                case "Sord":
                    isAttacking = false;
                    isAttacked = true;
                    Debug.Log("攻撃失敗");
                    m_AudioSource.PlayOneShot(AudioController.singleton.SEList[0]);
                    m_Controller.AttackCancel();
                    break;
            }
        }
    }
}