using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour
{
    [SerializeField] private float m_KillTimer;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(m_KillTimer);
        Destroy(gameObject);
        yield break;
    }

 }