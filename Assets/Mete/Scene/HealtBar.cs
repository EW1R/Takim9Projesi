using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public HealthM playerHealt;
    public Image totalHealt;
    public Image currentHealt;

    private void Start()
    {
        totalHealt.fillAmount = playerHealt.currentHealth = playerHealt.healthAmount;
    }

    private void Update()
    {
        currentHealt.fillAmount = playerHealt.currentHealth = playerHealt.healthAmount;
    }
}
