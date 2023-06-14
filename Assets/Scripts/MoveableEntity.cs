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
        [HideInInspector] public Animator anim;

        protected override void Awake()
        {
            base.Awake();
            destinationSetter = GetComponent<AIDestinationSetter>();
            anim = GetComponentInChildren<Animator>();

            aiLerp = GetComponent<AILerp>();
            aiLerp.canMove = false;
            aiLerp.speed = entityData.speed;
        }

        protected override void Update()
        {
            base.Update();
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
        /// <param name="subTask">whether or not this is a subtask</param>
        /// <param name="duration">how long the task should take in seconds, 0 means until the entity reaches the target</param>
        /// <returns></returns>
        protected IEnumerator Move(GameObject targetObject, bool subTask = false, float duration = 0)
        {
            float timer = duration;
            if (!subTask)
            {
                currentTaskFinished = false;
            }
            aiLerp.canMove = true;
            destinationSetter.target = targetObject.transform;
            anim.SetBool("Walking", true);
            Debug.Log("Moving.");
            LayerMask mask = LayerMask.GetMask("Ground");

            if (targetObject == null)
            {
                currentTaskFinished = true;
                yield break;
            }

            while (
                Vector3.Distance(transform.position, targetObject.transform.position) > entityData.range
                || Physics2D.Linecast(transform.position, targetObject.transform.position, mask)
                )
            {

                if (aiLerp.reachedEndOfPath)
                {
                    Debug.Log("Entity is stuck.");
                    break;
                }

                if (duration > 0)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        break;
                    }
                }
                yield return null;

                if (targetObject == null)
                {
                    currentTaskFinished = true;
                    yield break;
                }
            }

            Debug.Log("Reached target.");
            anim.SetBool("Walking", false);
            aiLerp.canMove = false;
            if (!subTask)
            {
                currentTaskFinished = true;
            }
        }
    }
}