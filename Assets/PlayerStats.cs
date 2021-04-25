using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats;
    // Start is called before the first frame update

    public void Display_HealthStats(float healthValue)
    {
        healthValue /= 100f;

        health_Stats.fillAmount = healthValue;
    }
}
