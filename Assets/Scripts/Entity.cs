using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private ScriptableObject entityData;

        [SerializeField]
        private float health, range;

        [SerializeField]
        private List<Func<GameObject, IEnumerator>> taskQueue = new();

        [SerializeField]
        private List<GameObject> targetQueue = new();

        private bool nextAction;

        [SerializeField]
        private GameObject target;

        private AIDestinationSetter destinationSetter;

        // Start is called before the first frame update
        void Awake()
        {
            target = new GameObject();
            destinationSetter = GetComponent<AIDestinationSetter>();
            destinationSetter.target = target.transform;
            AddTask(Move, target);
        }

        // Update is called once per frame
        void Update()
        {
            if (nextAction)
            {
                StartCoroutine(taskQueue[0](targetQueue[0]));
                //taskQueue[0].Invoke(targetQueue[0]);
                taskQueue.RemoveAt(0);
                targetQueue.RemoveAt(0);
                nextAction = false;
            }
        }

        void AddTask(Func<GameObject, IEnumerator> task, GameObject target)
        {
            taskQueue.Add(task);
            targetQueue.Add(target);
        }

        void CancelCurrentTask()
        {
            StopAllCoroutines();
            nextAction = true;
        }

        void CancelTask(int index)
        {
            taskQueue.RemoveAt(index);
            targetQueue.RemoveAt(index);
        }

        private IEnumerator Move(GameObject targetObject)
        {
            Debug.Log("Moving.");
            while (Vector3.Distance(transform.position, targetObject.transform.position) > range)
            {
                target.transform.position = targetObject.transform.position;
                yield return null;
            }

            nextAction = true;
        }
    }
}