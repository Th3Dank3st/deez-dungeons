using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public GameObject slider;
    public Color Low;
    public Color High;
    public Vector2 Offset;
    public GameObject enemy;
    private float duration = 50000;

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    private void Awake()
    {
        StartCoroutine(SliderFollower());
    }
    // void FixedUpdate()
    // {

    // }

    IEnumerator SliderFollower()
    {
        Vector2 enemypos = enemy.transform.position;
        float i = 0;
        while (i < duration)
        {
            slider.transform.position = Vector2.Lerp(slider.transform.position, enemypos + Offset, i / duration);
            i += Time.deltaTime;
            yield return null;
        }
    }
}
