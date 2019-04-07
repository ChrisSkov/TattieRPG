using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if(InteractWithCombat()) return;
            if(InteractWithMovement()) return;
            print("ain't shit here, boi");

        }

        private bool InteractWithCombat()
        {
            //hit things with a ray and store in an array
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            
            //loop through array. can we hit things?
            foreach(RaycastHit hit in hits)
            {
               CombatTarget target = hit.transform.GetComponent<CombatTarget>();

               //if we cannot attack
               if(!GetComponent<Fighter>().CanAttack(target))
               {
                    continue;//continue the loop
                }

               if(Input.GetMouseButtonDown(0))
               {
                    GetComponent<Fighter>().Attack(target);
               }
               return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {           
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if(Input.GetMouseButton(0))
                {
                GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

