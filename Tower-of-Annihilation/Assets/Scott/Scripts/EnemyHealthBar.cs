using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Singleton Pattern? */
public sealed class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Color transparent;
    public Vector3 offset;

    public void SetHealth(int healthBar, int maxHealthBar)
    {
        //Debug.Log(healthBar);
        //Debug.Log(maxHealthBar);
        slider.gameObject.SetActive(healthBar < maxHealthBar);
        slider.value = healthBar;
        slider.maxValue = maxHealthBar;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        if (healthBar < 1)
        {
            slider.fillRect.GetComponentInChildren<Image>().color = transparent;
        }

    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
