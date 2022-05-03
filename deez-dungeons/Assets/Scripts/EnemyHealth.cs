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
    public bool alreadyStunned = false;
    public bool alreadyBurning = false;
    public bool alreadyShocked = false;
    private float shockDPS = 50;
    private float burnDPS = 25;
    

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
        if (collisionGameObject.tag == "StunPlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyStunned)
            {
                StartCoroutine(Stunned2S());
            }
        }

        //Burn
        if (collisionGameObject.tag == "FirePlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyBurning)
            {
                StartCoroutine(Burn4S());
            }
        }

        //Shock
        if (collisionGameObject.tag == "ShockPlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyShocked)
            {
                StartCoroutine(Shock4S());
            }
        }
    }



    //Chill
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

    //Root
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

    //Stun
    public IEnumerator Stunned2S()
    {
        var path = gameObject.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        float i = 2f;

        while (i > 0)
        {
            if (!alreadyStunned)
            {
                gameObject.GetComponent<PathEnemyShooting>().enabled = false;
                path.maxSpeed = 0f;
                alreadyStunned = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        gameObject.GetComponent<PathEnemyShooting>().enabled = true;
        path.maxSpeed = originalSpeed;
        alreadyStunned = false;
        yield break;
        // All Done!        
    }

    //Burn
    public IEnumerator Burn4S()
    {

        float i = 4f;
        
        while (i > 0)
        {
            if (!alreadyBurning)
            {
                alreadyBurning = true;
            }
            UpdateHealth(-burnDPS);
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
                
        }
        alreadyBurning = false;
        yield break;
        // All Done!        
    }


    public IEnumerator Shock4S()
    {

        float i = 2f;

        while (i > 0)
        {
            if (!alreadyShocked)
            {
                alreadyShocked = true;
            }
            StartCoroutine(Root1S());
            UpdateHealth(-shockDPS);

            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(2f);

        }
        alreadyShocked = false;
        yield break;
        // All Done!        
    }

    public IEnumerator Root1S()
    {
        var path = gameObject.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        float i = 1f;

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




