using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public float range = 2.3f;
    //public float damage;
    //public GameObject hitEffect;
    //private Rigidbody2D rb;
    //public float slowDurationMustBe2 = 2f;
    //private GameObject enemy;
    public bool alreadySlowed = false;
    public bool alreadyRooted = false;
    

    private float health = 0f;
    [SerializeField] public float maxHealth = 100f;
    void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Destroy(this.gameObject);
        }
    }


    //hit effects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        //Chill
        if (collisionGameObject.tag == "ChillPlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadySlowed)
            {
                StartCoroutine(Chilled2S());
            }
        }
        //Root(immobilize)
        if (collisionGameObject.tag == "RootPlayerProjectile")
        {
            if (!alreadyRooted)
            {
                StartCoroutine(Root2S());
            }
        }
        //Stun
    }




    public IEnumerator Chilled2S()
    {
        var path = gameObject.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
         float i = 2f;

         while (i > 0)
         {
            if (!alreadySlowed)
            {
                path.maxSpeed *= 0.5f;
                alreadySlowed = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
             yield return new WaitForSeconds(1f);
         }            
         path.maxSpeed = originalSpeed;
         alreadySlowed = false;
         yield break;
         // All Done!        
    }

    public IEnumerator Root2S()
    {
        var path = gameObject.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        float i = 2f;

        while (i > 0)
        {
            if (!alreadyRooted)
            {
                path.maxSpeed = 0f;
                alreadyRooted = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        path.maxSpeed = originalSpeed;
        alreadyRooted = false;
        yield break;
        // All Done!        
    }
}




