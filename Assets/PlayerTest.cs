using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    
	public int maxHealth = 100;
	public int currentHealth;

	public PlayerHealthBar playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		playerHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(1);
		}
    }

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		playerHealthBar.SetHealth(currentHealth);
	}
}

