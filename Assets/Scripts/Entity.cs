using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anthell
{
    /// <summary>
    /// An abstract class to encapsulate entity task queues.
    /// </summary>
    abstract public class Entity : MonoBehaviour
    {
        [SerializeField]
        protected EntityData data;

        [SerializeField]
        protected Queue<EntityTask> taskQueue = new();
        protected EntityTask currentTask;
        protected bool currentTaskFinished = false;

        protected virtual void Awake()
        {
            currentTaskFinished = true;
        }

        private void Update()
        {
            if (currentTaskFinished && taskQueue.Count > 0)
            {
                currentTask = taskQueue.Dequeue();
                StartCoroutine(PerformTask(currentTask));
            }
        }
        /// <summary>
        /// Performs the task. To be run as a Coroutine.
        /// </summary>
        /// <param name="task">The task that is to be performed</param>
        /// <returns></returns>
        virtual protected IEnumerator PerformTask(EntityTask task)
        {
            switch (task.taskType)
            {
                case EntityTaskTypes.Idle:
                    yield return Idle();
                    break;
            }
        }
        /// <summary>
        /// An idle task. Sets the current task to finished.
        /// </summary>
        /// <returns></returns>
        protected IEnumerator Idle()
        {
            currentTaskFinished = false;
            Debug.Log("Idle task in progress");
            currentTaskFinished = true;
            yield return null;
        }
        /// <summary>
        /// Adds a task to the task queue.
        /// </summary>
        /// <param name="task">The task to be added to the task queue</param>
        public void AddTask(EntityTask task)
        {
            taskQueue.Enqueue(task);
            Debug.Log("Task added to queue.");
        }

        public void EndCurrentTask()
        {
            StopAllCoroutines(); // name is a bit weird, but it only stops coroutines on this behaviour
            taskQueue.Dequeue();
            currentTaskFinished = true;
        }
    }
}