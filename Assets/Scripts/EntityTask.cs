using UnityEngine;

namespace Anthell
{
    public enum EntityTaskTypes {
        Idle,
        Move,
        Attack,
        Dig,
        Build,
    };
    public struct EntityTask
    {
        public EntityTaskTypes taskType;
        // For tasks with no target, use the entity's own gameobject as the target.
        public GameObject target;

        public EntityTask(EntityTaskTypes taskType, GameObject targetGameObject) : this()
        {
            this.taskType = taskType;
            this.target = targetGameObject;
        }
    }
}
