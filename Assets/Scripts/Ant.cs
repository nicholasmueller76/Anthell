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

            currentTaskFinished = true;
        }

        protected IEnumerator Build(GameObject targetObject)
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

            currentTaskFinished = true;
        }
    }
}