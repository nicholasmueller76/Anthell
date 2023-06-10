using System.Collections;
using UnityEngine;
using cakeslice;

namespace Anthell
{
    class Ant : MoveableEntity
    {
        private float currentHealth;
        private Outline outline;

        protected override void Awake()
        {
            base.Awake();
            outline = GetComponentInChildren<Outline>();
            outline.eraseRenderer = true;
            currentHealth = data.maxHealth;
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
                case EntityTaskTypes.Dig:
                    yield return Dig(task.target);
                    break;
                case EntityTaskTypes.Build:
                    yield return Build(task.target);
                    break;
            }
        }

        protected IEnumerator Dig(GameObject targetObject)
        {
            if (Vector3.Distance(transform.position, targetObject.transform.position) <= data.range)
            {

                TileEntity tileEntity = targetObject.GetComponent<TileEntity>();
                currentTaskFinished = false;
                Debug.Log("Digging.");
                while (tileEntity.health > 0)
                {
                    yield return new WaitForSeconds(1f);
                    tileEntity.Dig(data.mineSpeed);

                }

                tileEntity.DestroyTile();
                Debug.Log("Finished digging");
            }
            else
            {
                Debug.Log("Could not execute dig task (out of range)");
            }

            currentTaskFinished = true;
        }

        protected IEnumerator Build(GameObject targetObject)
        {
            if (Vector3.Distance(transform.position, targetObject.transform.position) <= data.range)
            {
                //Will need to add some way to pass the material as a parameter

                TileEntity tileEntity = targetObject.GetComponent<TileEntity>();
                currentTaskFinished = false;
                Debug.Log("Building.");

                //Currently flat time for building
                yield return new WaitForSeconds(1f);

                Debug.Log(tileEntity);

                tileEntity.PlaceTile(TileEntity.TileTypes.Dirt);
                Debug.Log("Finished building");
            }
            else
            {
                Debug.Log("Could not execute build task (out of range)");
            }

            currentTaskFinished = true;
        }

        public void SetSelected(bool selected)
        {
            outline.eraseRenderer = !selected;
        }
    }
}