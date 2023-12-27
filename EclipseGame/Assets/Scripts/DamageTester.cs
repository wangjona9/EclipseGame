using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;

    private void Update()
    {
        // Check if both playerAtm and enemyAtm are not null before proceeding
        if (playerAtm != null && enemyAtm != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerAtm.DealDamage(enemyAtm.gameObject);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                enemyAtm.DealDamage(playerAtm.gameObject);

                // Check if enemyAtm's health is 0 or less
                if (enemyAtm.health <= 0)
                {
                    DestroyEnemy();
                }
            }

            // Check if enemyAtm's health is 0 or less
            if (enemyAtm.health <= 0)
            {
                DestroyEnemy();
            }
        }
    }

    private void DestroyEnemy()
    {
        // Destroying the game object associated with the enemyAtm
        // If you decide to deactivate instead of destroy, replace the following line:
        Destroy(enemyAtm.gameObject);
        // with:
        // enemyAtm.gameObject.SetActive(false);
    }
}