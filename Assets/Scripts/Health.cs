using UnityEngine;
using UnityEngine.SceneManagement;
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
                GameObject.Instantiate(GetComponent<Entity>().deathParticles, this.transform.position, Quaternion.identity);
                if(GetComponent<Entity>().deathSound == "GameOver")
                {
                    FindObjectOfType<AudioManager>().StopMusic();
                    SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                }
                AudioManager.instance.PlaySFX(GetComponent<Entity>().deathSound, false);
                Destroy(gameObject);
            }
            else
            {
                GameObject.Instantiate(GetComponent<Entity>().damageParticles, this.transform.position, Quaternion.identity);
                AudioManager.instance.PlaySFX(GetComponent<Entity>().damageSound, false);
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