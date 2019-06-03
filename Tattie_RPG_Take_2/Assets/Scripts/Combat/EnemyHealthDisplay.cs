using System;
using RPG.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter Fighter;

        private void Awake()
        {
            Fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }


        private void Update()
        {
            if(Fighter.GetTarget() == null)
            {
                GetComponent<Text>().text = "N/A";
            }
            Health health = Fighter.GetTarget();

            GetComponent<Text>().text = String.Format("{0:0}%", health.GetPercentage());
        }
    }

}