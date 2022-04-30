using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public float maxHealth = 100f;
	private float currentHealth;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	public void UpdateHealth(float damage)
	{
		currentHealth += damage;

		healthBar.SetHealth(currentHealth);

		if (currentHealth > maxHealth)
		{
		currentHealth = maxHealth;
		}
		
		else if (currentHealth <= 0) 
		{
		currentHealth = 0;

			FindObjectOfType<LevelManager>().Restart();
		}
	}
}








//STAY ALIVE FUNCTION
//if (currentHealth > maxHealth)
//{
//currentHealth = maxHealth;
//}
//PLAYER RESPAWN/DIE
//else if (currentHealth <= 0) 
//{
//currentHealth = 0;

//Debug.Log("Player Respawn");
//}
