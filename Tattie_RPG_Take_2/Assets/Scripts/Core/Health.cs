using System.Collections;
using System.Collections.Generic;
using RPG.Saving;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Core
{
    public class Health : MonoBehaviour, ISaveable
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

        public object CaptureState()
        {
            return healthPoints;
        }

        public void RestoreState(object state)
        {
            healthPoints = (float) state;
            if(healthPoints <= 0)
            {
                Die();
            }
        }
    }
}
