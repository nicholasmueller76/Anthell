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
        private EntityData data;

        [SerializeField]
        private Queue<EntityTask> taskQueue = new();
        private EntityTask currentTask;
        private bool currentTaskFinished = false;

        private void Awake()
        {
            currentTaskFinished = true;
            // For testing purposes add 5 idle tasks to the queue.
            for (int i = 0; i < 5; i++)
            {
                var idleStartTask = new EntityTask(EntityTaskTypes.Idle, this.gameObject);
                taskQueue.Enqueue(idleStartTask);
            }
        }

        private void Update()
        {
            if (currentTaskFinished && taskQueue.Count > 0)
            {
                currentTask = taskQueue.Dequeue();
                StartCoroutine(PerformTask(currentTask));
            }
        }

        private IEnumerator PerformTask(EntityTask task)
        {
            switch (task.taskType)
            {
                case EntityTaskTypes.Idle:
                    yield return Idle();
                    break;
            }
        }

        private IEnumerator Idle()
        {
            currentTaskFinished = false;
            Debug.Log("Idle task in progress");
            currentTaskFinished = true;
            yield return null;
        }

        public void AddTask(EntityTask task)
        {
            taskQueue.Enqueue(task);
        }

        public void EndCurrentTask()
        {
            taskQueue.Dequeue();
        }
    }
}