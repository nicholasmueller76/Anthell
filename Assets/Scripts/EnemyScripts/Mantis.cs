using System.Collections;
using UnityEngine;

namespace Anthell
{
    class Mantis : Enemy
    {
        [SerializeField] private GameObject queenAnt;
        protected override void Awake()
        {
            base.Awake();
            taskQueue.Enqueue(new EntityTask(EntityTaskTypes.Attack, queenAnt));
        }

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
                // find nearest ant within range
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, entityData.range);
                bool foundAnAnt = false;
                Ant nearestAnt = null;

                if (hitColliders.Length >= 1)
                {
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
                }

                if (foundAnAnt)
                {
                    Debug.Log("Attacking ant");
                    nearestAnt.health.TakeDamage(entityData.attackDamage);
                    //delay for animation
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    yield return Move(targetObject, true, 0.5f);
                }
            }
            Debug.Log("Finished attacking");

            currentTaskFinished = true;
        }
    }
}

