using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class OrkController : EnemyController
    {
        [SerializeField] private float speed;
        [SerializeField] private int hp;
        [SerializeField] private int mp;
        [SerializeField] private int atk;
        [SerializeField] private int def;
        [SerializeField] private float talent;

        protected override void Start()
        {
            status = new Status(spawnLevel, 0, hp, mp, atk, def, talent);
            ChangeState(State.Walk);
        }

        protected override void ChangeState(State state)
        {
            base.ChangeState(state);
            switch (state)
            {
                case State.Walk: StartCoroutine(WalkState()); break;
                case State.Battle: StartCoroutine(BattleState()); break;
            }
        }

        private IEnumerator WalkState()
        {
            Vector3 pos, targetPos;
            float distance;

            while (true)
            {
                pos = transform.position;
                targetPos = PlayerController.singleton.transform.position;
                pos.y = targetPos.y;
                distance = Vector3.Distance(transform.position, PlayerController.singleton.transform.position);

                Debug.Log(distance);

                Move(transform.forward, speed);
                Rotate(speed);

                if (distance <= 1.5f)
                {
                    ChangeState(State.Battle);
                    yield break;
                }
                yield return null;
            }
        }

        private IEnumerator BattleState()
        {
            Vector3 pos, targetPos;
            float distance;
            float span = 1.0f;

            while (true)
            {
                pos = transform.position;
                targetPos = PlayerController.singleton.transform.position;
                pos.y = targetPos.y;
                distance = Vector3.Distance(transform.position, PlayerController.singleton.transform.position);

                Debug.Log(distance);

                span -= Time.deltaTime;
                if (span <= 0)
                {
                    Attack();
                    span = Random.Range(1.0f, 1.5f);
                    m_Animator.SetTrigger("Idle");
                    yield return new WaitForSeconds(5.0f);
                }
                else
                {
                    Rotate(speed);
                    if (distance < 1.25f)
                        Move(transform.forward * -1, speed);

                }

                if (distance > 1.5f)
                {
                    ChangeState(State.Walk);
                    yield break;
                }
                yield return null;
            }
        }

        protected override void Attack()
        {
            base.Attack();
            m_Animator.SetTrigger("Attack");
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.gameObject == gameObject) return;
            switch (other.tag)
            {
                case "Enemy":
                    {
                        Debug.Log("Hit Enemy on Enemy");
                        Move(transform.position - other.transform.position, speed);
                    }
                    break;
            }
        }
    }
}