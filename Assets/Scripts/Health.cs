using UnityEngine;
namespace Anthell
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth;
        private bool healthBarEnabled = false;
        private Vector3 healthBarPosition;

        private void Update()
        {
            if (healthBarEnabled)
            {
                // Code to update health bar
            }
        }

        public void enableHealthBar()
        {
            healthBarEnabled = true;
        }

        public void setHealthBarPosition(Vector3 position)
        {
            healthBarPosition = position;
        }

        public void disableHealthBar()
        {
            healthBarEnabled = false;
            // Code to disable health bar
        }

        public void SetHealth(float newHealthValue)
        {
            currentHealth = newHealthValue;
        }

        public float getHealth()
        {
            return currentHealth;
        }

        public void SetMaxHealth(float newMaxHealthValue)
        {
            maxHealth = newMaxHealthValue;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if(GetComponent<Enemy>() != null)
                {
                    ResourceManager.instance.AddCash(GetComponent<Enemy>().GetData().cashCost);
                }
                Destroy(gameObject);
            }
        }

        public void Heal(float healAmount)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}