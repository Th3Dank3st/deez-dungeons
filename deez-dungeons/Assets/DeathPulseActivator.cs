using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPulseActivator : MonoBehaviour
{
    public GameObject deathPulse;
    //public int indicatorDuration;
    public int indicatorDuration;
  
    void Start()
    {

        StartCoroutine(Indicator());
    }

    private void Update()
    {
        
    }


    IEnumerator Indicator()
    { 
        Vector2 indicatorPos = this.gameObject.GetComponent<Transform>().position;
        while (indicatorDuration > 0)
        {
            indicatorDuration--;
            yield return new WaitForSeconds(1f);
        }
            GameObject newEnemy = Instantiate(deathPulse, indicatorPos, Quaternion.identity);
            Destroy(this.gameObject);
            //Destroy(newEnemy, 4f);
            yield break;
    }

}
