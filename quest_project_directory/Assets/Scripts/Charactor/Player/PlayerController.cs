using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController singleton;

        public Status status;

        private void Awake()
        {
            if (singleton != null)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                return;
            }
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            status = new Status(1, 0, 10, 6, 6, 6, 0.2f);
        }

        private void Update()
        {

        }

        protected virtual void Attack()
        {

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
        }
    }
}