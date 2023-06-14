using System.Collections;
using UnityEngine;

namespace Anthell
{
    class AcidMaggot : Enemy
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
            Ant nearestAnt = null;
            // get ant that is closest to this object
            float distance = Mathf.Infinity;
            foreach (var collider in hitColliders)
            {
                var ant = collider.GetComponent<Ant>();
                if (ant != null && ant.health.getHealth() > 0)
                {
                    // if there is a line of sight to the ant from the beetle
                    if (Physics2D.Linecast(transform.position, ant.transform.position))
                    {
                        foundAnAnt = true;
                        float newDistance = Vector3.Distance(transform.position, collider.transform.position);
                        if (newDistance < distance)
                        {
                            distance = newDistance;
                            nearestAnt = ant;
                        }
                    }
                }
            }
            if (!foundAnAnt)
            {
                yield break;
            }
            else
            {
                Debug.Log("Attacking ant");
                nearestAnt.health.TakeDamage(entityData.attackDamage);
            }
            //delay for animation
            yield return new WaitForSeconds(1f);
        }
    }
}

