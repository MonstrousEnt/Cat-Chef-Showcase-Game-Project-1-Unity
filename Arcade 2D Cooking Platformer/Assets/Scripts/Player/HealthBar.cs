using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private List <GameObject> healthIconGameObjects;
    [SerializeField] private List<GameObject> healthIconGameObjectsFill;
    [SerializeField] private int healthIconMax;

    public int GetHealthIconMax() { return healthIconMax; }

    private void SetHealthIcon(int index, bool flag, int health)
    {
        if (healthIconMax <= health)
        {
            //Enable fill icon
            healthIconGameObjects[index].SetActive(flag);
        }
    }

    public int SetHealthPowerUp(int health)
    {
        health = health + PlayerBase.instance.GetHealthIconNum();
        healthIconMax = healthIconMax + 1;
        Debug.Log(healthIconMax);
        SetHealthIcon(healthIconMax - 1, true, health);
        return health;
    }

    public void TakeHealthIcon(int health, int index)
    {
        healthIconMax = healthIconMax - 1;
        Debug.Log(healthIconMax);

        if (healthIconMax <= health)
        {
            healthIconGameObjectsFill[healthIconMax].SetActive(false);
        }
       
    }

    public void SetCurrentHealthIcon(int healthIconMax, bool flag, int health)
    {
        for (int i = 0; i < healthIconMax; i++)
        {
            SetHealthIcon(i, flag, health);
        }
    }
}


