using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public GameObject enemy;
    private Vector3 enemypos;
    private float duration = .1f;


    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }
    private void Awake()
    {
        //StartCoroutine(SliderFollower());
    }
    private void FixedUpdate()
    {
        StartCoroutine(SliderFollower());
    }
    IEnumerator SliderFollower()
    {
        enemypos = enemy.transform.position;
        float i = 0;
        while (i < duration)
        {
            
            Slider.transform.position = Vector3.Lerp(Slider.transform.position, enemypos + Offset, i / duration);
            i += Time.deltaTime;
            yield return null;
        }
    }
}
