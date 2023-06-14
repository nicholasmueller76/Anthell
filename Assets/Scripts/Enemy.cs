using System.Collections;
using UnityEngine;

namespace Anthell
{
    abstract class Enemy : MoveableEntity
    {
        private SpriteRenderer sprite;
        public GameObject queenAnt;

        protected override void Awake()
        {
            base.Awake();
            sprite = GetComponentInChildren<SpriteRenderer>();
        }

        public void setQueenAnt(GameObject queenAnt)
        {
            this.queenAnt = queenAnt;
        }

        protected override void Update()
        {
            base.Update();
            sprite.transform.eulerAngles = new Vector3(0, 0, 0);

            if (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z <= 180)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            
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