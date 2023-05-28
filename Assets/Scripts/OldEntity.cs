using System;
using System.Collections;
using System.Collections.Generic;
using Anthell;
using UnityEngine;

namespace Pathfinding
{
    public class Entity : MonoBehaviour
    {
        [SerializeField]
        private EntityData data;

        [SerializeField]
        private float currentHealth;

        private List<Func<GameObject, EntityTaskTypes>> taskQueue = new();

        private List<GameObject> targetQueue = new();

        private bool nextAction = false;

        [SerializeField]
        private GameObject target;

        //The script that controls where the ant should pathfind to.
        private AIDestinationSetter destinationSetter;

        private AILerp aiLerp;

        void Awake()
        {
            target = new GameObject();
            target.name = name + " target";
            
            destinationSetter = GetComponent<AIDestinationSetter>();
            destinationSetter.target = target.transform;
            
            aiLerp = GetComponent<AILerp>();
            aiLerp.canMove = false;
            aiLerp.speed = data.speed;

            currentHealth = data.maxHealth;

            AddTask(Move, target);
            nextAction = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (nextAction && taskQueue.Count > 0)
            {
                taskQueue.RemoveAt(0);
                targetQueue.RemoveAt(0);
                nextAction = false;
            }
        }

        //Adds a task with the corresponding target (which should be an Entity or TileEntity).
        void AddTask(Func<GameObject, IEnumerator> task, GameObject target)
        {
            targetQueue.Add(target);
        }

        //Cancels the current ongoing task.
        void CancelCurrentTask()
        {
            StopAllCoroutines();
            nextAction = true;
        }

        //Cancels the task at index.
        void CancelTask(int index)
        {
            taskQueue.RemoveAt(index);
            targetQueue.RemoveAt(index);
        }

        //Moves to targetObject until within range.
        private IEnumerator Move(GameObject targetObject)
        {
            aiLerp.canMove = true;
            Debug.Log("Moving.");
            while (Vector3.Distance(transform.position, targetObject.transform.position) > data.range)
            {
                target.transform.position = targetObject.transform.position;
                yield return null;
            }

            Debug.Log("Reached target.");

            aiLerp.canMove = false;
            nextAction = true;
        }
    }
}