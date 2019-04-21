using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
       // public Slider slider;

        
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;

        public float getHealth()
        {
            
            {
                return healthPoints;
            }
        }

        public bool IsDead()
        {
            return isDead;
        }

   

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if (healthPoints == 0)
            {
                Die();
            }

        }

        public void Die()
        {
            {
                if (isDead) return;

                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }
        }
    }
}
