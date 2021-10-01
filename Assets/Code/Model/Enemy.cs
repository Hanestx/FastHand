using System;
using System.Collections;
using UnityEngine;

namespace FastHand
{
    internal class Enemy : MonoBehaviour, IDamage
    {
        public float Health => _health;

        private float _health = 100f;
        private Action _damageDelegate;

        private void Start()
        {
            _damageDelegate += AddDamage;
        }

        public void AddDamage()
        {
            _health -= 100;
            Debug.Log(Health.ToString());

            if (_health <= 0) 
                DieAnimation();
        }
        
        public void DieAnimation()
        {
            WanderingAI behaviour = GetComponent<WanderingAI>();
            
            if (behaviour is WanderingAI)
            {
                behaviour.SetAlive(false);
                StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {
            this.transform.Rotate(-75, 0, 0);
            yield return new WaitForSeconds(1.50f);
            gameObject.SetActive(false);
        }
    }
}