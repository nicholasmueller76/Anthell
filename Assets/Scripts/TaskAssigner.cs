using UnityEngine;

namespace Anthell
{
    class TaskAssigner
    {
        private Ant selectedAnt;
        private GameObject selectedTarget;
        private EntityTaskTypes selectedTaskType;

        public void SetNextTaskAnt(Ant ant)
        {
            selectedAnt = ant;
            Debug.Log("Selected ant: " + selectedAnt.name);
        }

        public void SetNextTaskTarget(GameObject target)
        {
            selectedTarget = target;
            Debug.Log("Selected target: " + selectedTarget.name);
        }

        public void SetNextTaskType(EntityTaskTypes taskType)
        {
            selectedTaskType = taskType;
            Debug.Log("Selected task type: " + selectedTaskType);
        }

        public void AssignNextTask()
        {
            if (selectedAnt != null && selectedTarget != null)
            {
                // Debug.Log("Assigning task.");
                selectedAnt.AddTask(new EntityTask(selectedTaskType, selectedTarget));
                selectedAnt = null;
                selectedTarget = null;
                selectedTaskType = EntityTaskTypes.Idle;
            }
        }
    }
}