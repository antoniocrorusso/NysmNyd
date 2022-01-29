using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void damageHeart()
    {
        currentHealth -= 1;
    }

    public void recoverHeart()
    {
        currentHealth += 1;
    }

    public void increaseHealthbar()
    {
        if (maxHealth < 10)
        {
            maxHealth += 1;
            currentHealth += 1;
        } else
        {
            maxHealth = 10;
        }
        
    }
}
