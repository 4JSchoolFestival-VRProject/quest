using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class EnemyController : MonoBehaviour
    {
        protected enum State
        {
            Walk,
            Battle,
        }

        protected CharacterController m_CharacterController;
        protected Animator m_Animator;

        [SerializeField] private GameObject m_ExplosionPrefab;
        [SerializeField] EnemyWeapon weapon;

        public Status status;
        public int spawnLevel;
        public int exp = 1;

        protected State state = State.Walk;

        protected virtual void Awake()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Animator = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            status = new Status();
        }

        protected virtual void Update()
        {
            if (weapon != null)
                weapon.isAttacking = m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        }

        protected virtual void ChangeState(State state)
        {
            this.state = state;
        }

        protected void Move(Vector3 dir, float speed)
        {
            dir.Normalize();
            // m_CharacterController.Move(dir * speed * Time.deltaTime);
            m_CharacterController.SimpleMove(dir * speed);
            m_Animator.SetTrigger("Walk");
        }

        protected void Rotate(float speed)
        {
            Vector3 target = PlayerController.singleton.transform.position;
            Vector3 pos = transform.position;
            pos.y = target.y;

            Quaternion to = Quaternion.LookRotation(target - pos);
            Quaternion r = Quaternion.RotateTowards(transform.rotation, to, 90.0f * speed * Time.deltaTime);
            transform.rotation = r;
        }

        protected virtual void Attack()
        {
            m_Animator.SetTrigger("Attack");
            weapon.isAttacked = false;
        }

        public virtual void AttackCancel()
        {
            m_Animator.SetTrigger("AttackChancel");
        }

        public void AddDamage(int atk)
        {
            int damage = atk - status.parameters.def;
            if (damage <= 0) damage = 1;
            status.AddDamage(damage);
            if (status.parameters.hp <= 0) Death();
        }

        public void Death()
        {
            Instantiate(m_ExplosionPrefab, transform.position, transform.rotation);
            PlayerController.singleton.status.AddExp(exp);
            Destroy(gameObject);
        }
    }
}