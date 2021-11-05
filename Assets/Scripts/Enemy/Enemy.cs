using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth;
	public float health;

	public HealthBar healthBar;

	public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]

	private bool isDead = false;
	void Start()
    {
        health = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(float amount)
	{
		health -= amount;
		healthBar.SetHealth((int)health);

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	// Update is called once per frame
	void Die()
	{
		isDead = true;

		Score.scoreValue += 10;
		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(gameObject);
	}
}
