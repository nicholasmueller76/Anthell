using System.Collections;
using UnityEngine;

namespace Anthell
{
    class TestEnemy : Enemy
    {
        protected override IEnumerator AttackSequence(GameObject targetObject)
        {
            Ant queenAnt = targetObject.GetComponent<Ant>();
            if (queenAnt == null)
            {
                Debug.Log("Could not execute attack task (target is not an enemy)");
                yield break;
            }
            currentTaskFinished = false;
            Debug.Log("Attacking.");
            while (queenAnt.health.getHealth() > 0)
            {
                if (Vector3.Distance(transform.position, targetObject.transform.position) > entityData.range)
                {
                    yield return this.Move(targetObject, true, entityData.attackCooldown);
                }
                else
                {
                    yield return new WaitForSeconds(entityData.attackCooldown);
                }
                yield return Attack();
            }
            Debug.Log("Finished attacking");

            currentTaskFinished = true;
        }

        protected IEnumerator Attack()
        {
            // get all Ants within data.range
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, entityData.range);
            bool foundAnAnt = false;
            foreach (Collider2D collider in hitColliders)
            {
                Ant ant = collider.gameObject.GetComponent<Ant>();
                if (ant != null)
                {
                    foundAnAnt = true;
                    // attack the ant
                    ant.health.TakeDamage(entityData.attackDamage);
                    Debug.Log("Attacked an ant!");
                }
            }
            if (!foundAnAnt)
            {
                yield break;
            }
            //delay for animation
            yield return new WaitForSeconds(1f);
        }
    }
}

