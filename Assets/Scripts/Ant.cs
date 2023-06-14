using System.Collections;
using UnityEngine;
using cakeslice;

namespace Anthell
{
    class Ant : MoveableEntity
    {
        [HideInInspector] public Health health;
        private Outline outline;
        private ResourceManager resourceManager;
        private TileEntity.TileTypes heldResource;
        private SpriteRenderer sprite;

        [SerializeField] string attackSfxName;

        protected override void Awake()
        {
            base.Awake();
            outline = GetComponentInChildren<Outline>();
            sprite = GetComponentInChildren<SpriteRenderer>();
            outline.eraseRenderer = true;
            health = gameObject.AddComponent<Health>();
            health.SetHealth(entityData.maxHealth);
            health.SetMaxHealth(entityData.maxHealth);
            resourceManager = Camera.main.gameObject.GetComponent<ResourceManager>();
        }

        protected override void Update()
        {
            base.Update();
            if (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z <= 180)
            {
                sprite.gameObject.transform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                sprite.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            if (taskQueue.Count == 0 && currentTaskFinished && entityData.autoAttack)
            {
                AttackEnemyIfNear();
            }
        }

        protected void AttackEnemyIfNear()
        {
            // line cast for enemies within radius
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, entityData.range);
            bool foundAnEnemy = false;
            Enemy nearestEnemy = null;
            // get enemy that is closest to this object
            float distance = Mathf.Infinity;
            foreach (var collider in hitColliders)
            {
                if (collider.CompareTag("Enemy") == false)
                {
                    continue;
                }
                var enemy = collider.GetComponent<Enemy>();
                if (enemy != null && enemy.health.getHealth() > 0)
                {
                    LayerMask mask = LayerMask.GetMask("Ground");
                    // if there is a line of sight to the enemy from the ant
                    if (!Physics2D.Linecast(transform.position, enemy.transform.position, mask))
                    {
                        foundAnEnemy = true;
                        float newDistance = Vector3.Distance(transform.position, collider.transform.position);
                        if (newDistance < distance)
                        {
                            distance = newDistance;
                            nearestEnemy = enemy;
                        }
                    }

                }
            }
            if (foundAnEnemy)
            {
                AddTask(new EntityTask(EntityTaskTypes.Attack, nearestEnemy.gameObject));
            }
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
                case EntityTaskTypes.Attack:
                    yield return Attack(task.target);
                    break;
            }
        }

        protected IEnumerator Dig(GameObject targetObject)
        {
            if (Vector3.Distance(transform.position, targetObject.transform.position) <= entityData.range)
            {

                TileEntity tileEntity = targetObject.GetComponent<TileEntity>();
                currentTaskFinished = false;
                Debug.Log("Digging.");

                FindObjectOfType<AudioManager>().PlaySFX("Break" + tileEntity.GetTileName(), true);

                while (tileEntity.health > 0)
                {
                    tileEntity.Dig(entityData.mineSpeed[(int)tileEntity.GetTileType()]);
                    yield return new WaitForSeconds(1f);

                }

                Debug.Log("Adding resource: " + tileEntity.GetTileType());
                resourceManager.AddResource(tileEntity.GetTileType(), 1);

                FindObjectOfType<AudioManager>().StopSFX("Break" + tileEntity.GetTileName());
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
            if (Vector3.Distance(transform.position, targetObject.transform.position) <= entityData.range && heldResource != TileEntity.TileTypes.Empty)
            {
                TileEntity tileEntity = targetObject.GetComponent<TileEntity>();
                currentTaskFinished = false;
                Debug.Log("Building.");

                float buildPercent = 0;
                while (buildPercent < 100)
                {
                    yield return new WaitForSeconds(1f);
                    buildPercent += entityData.buildSpeed;
                }

                Debug.Log(tileEntity);

                tileEntity.PlaceTile(heldResource);
                resourceManager.AddResource(heldResource, -1);
                heldResource = TileEntity.TileTypes.Empty;
                Debug.Log("Finished building");
            }
            else
            {
                Debug.Log("Could not execute build task (out of range or missing resource)");
            }

            currentTaskFinished = true;
        }

        protected IEnumerator Attack(GameObject targetObject)
        {
            Enemy enemy = targetObject.GetComponent<Enemy>();
            if (enemy == null)
            {
                Debug.Log("Could not execute attack task (target is not an enemy)");
                yield break;
            }
            currentTaskFinished = false;
            Debug.Log("Attacking.");
            while (enemy != null && enemy.health.getHealth() > 0)
            {
                LayerMask mask = LayerMask.GetMask("Ground");
                if (Vector3.Distance(transform.position, targetObject.transform.position) > entityData.range
                || Physics2D.Linecast(transform.position, targetObject.transform.position, mask)
                )
                {
                    yield return this.Move(targetObject, true);
                }
                yield return new WaitForSeconds(entityData.attackCooldown);
                AudioManager.instance.PlaySFX(attackSfxName, false);
                if (enemy != null) enemy.health.TakeDamage(entityData.attackDamage);
            }
            Debug.Log("Finished attacking");

            currentTaskFinished = true;
        }

        public void SetSelected(bool selected)
        {
            outline.eraseRenderer = !selected;
        }

        public void SetHeldResource(TileEntity.TileTypes resource)
        {
            heldResource = resource;
        }
    }
}