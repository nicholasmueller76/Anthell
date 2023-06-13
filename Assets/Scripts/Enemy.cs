using System.Collections;
using UnityEngine;

namespace Anthell
{
    class Enemy : MoveableEntity
    {
        public Health health;
        private SpriteRenderer sprite;

        protected override void Awake()
        {
            base.Awake();
            health = gameObject.AddComponent<Health>();
            health.SetHealth(data.maxHealth);
            health.SetMaxHealth(data.maxHealth);
            sprite = GetComponentInChildren<SpriteRenderer>();
        }

        protected override void Update()
        {
            base.Update();
            sprite.flipY = (this.transform.rotation.eulerAngles.z >= 0 && this.transform.rotation.eulerAngles.z <= 180);
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

        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Ant"))
            {
                //Attack logic.
            }
        }
    }
}