using System.Collections;
using UnityEngine;
using Pathfinding;

namespace Anthell
{
    abstract class MoveableEntity : Entity
    {
        // The script that controls where the ant should pathfind to.
        protected AIDestinationSetter destinationSetter;
        protected AILerp aiLerp;
        // Serialized Field for testing purposes.
        [SerializeField] protected GameObject moveTarget;

        protected override void Awake()
        {
            base.Awake();
            destinationSetter = GetComponent<AIDestinationSetter>();

            aiLerp = GetComponent<AILerp>();
            aiLerp.canMove = false;
            aiLerp.speed = data.speed;
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

        /// <summary>
        /// Moves to targetObject until within range.
        /// </summary>
        /// <param name="targetObject">location or object the entity needs to move to</param>
        /// <returns></returns>
        protected IEnumerator Move(GameObject targetObject)
        {
            currentTaskFinished = false;
            aiLerp.canMove = true;
            destinationSetter.target = moveTarget.transform;
            Debug.Log("Moving.");
            while (Vector3.Distance(transform.position, targetObject.transform.position) > data.range)
            {
                moveTarget.transform.position = targetObject.transform.position;
                yield return null;
            }

            Debug.Log("Reached target.");

            aiLerp.canMove = false;
            currentTaskFinished = true;
        }
    }
}