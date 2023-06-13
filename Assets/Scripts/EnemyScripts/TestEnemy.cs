using System.Collections;
using UnityEngine;

namespace Anthell
{
    class TestEnemy : Enemy
    {
        [SerializeField] private GameObject queenAnt;
        protected override void Awake()
        {
            base.Awake();
            taskQueue.Enqueue(new EntityTask(EntityTaskTypes.Attack, queenAnt));
        }
        protected override IEnumerator Attack()
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

