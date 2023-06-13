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
        /// then attack the target object until it is dead.
        /// Attacks ants on the way to the target object.
        /// </summary>
        /// <param name="targetObject"></param>
        /// <returns></returns>
        abstract protected IEnumerator AttackSequence(GameObject targetObject);

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ant"))
            {
                //Attack logic.
            }
        }
    }
}