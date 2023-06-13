using System.Collections;
using UnityEngine;

namespace Anthell
{
    abstract class Enemy : MoveableEntity
    {
        public Health health;
        private SpriteRenderer sprite;

        protected override void Awake()
        {
            base.Awake();
            health = gameObject.AddComponent<Health>();
            health.SetHealth(entityData.maxHealth);
            health.SetMaxHealth(entityData.maxHealth);
            sprite = GetComponentInChildren<SpriteRenderer>();
        }

        protected override void Update()
        {
            base.Update();
            sprite.flipY = (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z <= 180);
        }

        protected override IEnumerator PerformTask(EntityTask task)
        {
            switch (task.taskType)
            {
                case EntityTaskTypes.Idle:
                    yield return Idle();
                    break;
                case EntityTaskTypes.Move:
                    yield return Move(task.target);
                    break;
                case EntityTaskTypes.Attack:
                    yield return AttackSequence(task.target);
                    break;
            }
        }

        /// <summary>
        /// Move towards the target object until within range,
        /// attack enemies within range every data.attackCooldown seconds.
        /// </summary>
        /// <param name="targetObject"></param>
        /// <returns></returns>
        protected IEnumerator AttackSequence(GameObject targetObject)
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

        abstract protected IEnumerator Attack();

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ant"))
            {
                //Attack logic.
            }
        }
    }
}