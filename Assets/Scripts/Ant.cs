using System.Collections;
using UnityEngine;

namespace Anthell
{
    class Ant : MoveableEntity
    {
        private float currentHealth;
        protected override void Awake()
        {
            base.Awake();
            currentHealth = data.maxHealth;

            AddTask(new EntityTask(EntityTaskTypes.Move, moveTarget));
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
            }
        }
    }
}