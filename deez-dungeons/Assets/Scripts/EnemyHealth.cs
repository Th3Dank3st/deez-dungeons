using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject stunIndicator;
    public GameObject slowIndicator;
    public float Experience;
    public bool alreadySlowed = false;
    public bool alreadyRooted = false;
    public bool alreadyStunned = false;
    public bool alreadyBurning = false;
    public bool alreadyShocked = false;
    public bool isWarlock;
    private float shockDPS = 50;
    private float burnDPS = 20;
    public GameObject phase1;
    private bool alreadyActive = false;
    private float health;
    public GameObject shockAnimation;
    public GameObject burnAnimation;
    public HealthbarBehaviour Healthbar;
    public GameObject healthBar;

    //public GameObject item1;
    //public GameObject item2;
    //public GameObject item3;
    public GameObject[] items;
    public Transform spawnLocation;

    [SerializeField] public float maxHealth;
    void Awake()
    {
        shockDPS *= FindObjectOfType<PlayerMovement>().spellDamage;
        burnDPS *= FindObjectOfType<PlayerMovement>().spellDamage;
        //enemyHealthBar.SetMaxHealth(maxHealth);
        health = maxHealth;        
    }
    private void Update()
    {
        Healthbar.SetHealth(health, maxHealth);
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        healthBar.SetActive(true);
        //enemyHealthBar.SetHealth(health);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if(health < 1500 && isWarlock && !alreadyActive)
        {
            alreadyActive = true;
            phase1.SetActive(true);
            gameObject.GetComponent<PathEnemyShooting>().enabled = false;           
        }
        else if (health <= 0f)
        {
            float droprate = Random.Range(1, 100);
            if (droprate <= 5)
            {
                Instantiate(items[Random.Range(0, 3)], spawnLocation.position, spawnLocation.rotation);
            }
            FindObjectOfType<PlayerMovement>().UpdateXP(Experience);
            health = 0f;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

        //Mini Stun
        if (collisionGameObject.tag == "MiniStunPlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyStunned)
            {
                StartCoroutine(MiniStun());
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
                StartCoroutine(Shock6S());
            }
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

        //Mini Stun
        if (collisionGameObject.tag == "MiniStunPlayerProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyStunned)
            {
                StartCoroutine(MiniStun());
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
                StartCoroutine(Shock6S());
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
                slowIndicator.SetActive(true);
                path.maxSpeed *= 0.5f;
                alreadySlowed = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
             yield return new WaitForSeconds(1f);
         }
        slowIndicator.SetActive(false);
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
             //   slowAnimation.SetActive(true);
                path.maxSpeed = 0f;
                alreadyRooted = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
       // slowAnimation.SetActive(false);
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
                if (gameObject.GetComponent<PathEnemyShooting>() != null)
                {
                    gameObject.GetComponent<PathEnemyShooting>().enabled = false;                    
                }
                if (gameObject.GetComponent<GolemLazerAttack>() != null)
                {
                    gameObject.GetComponent<GolemLazerAttack>().enabled = false;
                }
                path.maxSpeed = 0f;
                alreadyStunned = true;
                stunIndicator.SetActive(true);
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        stunIndicator.SetActive(false);
        if (gameObject.GetComponent<PathEnemyShooting>() != null)
        {
            gameObject.GetComponent<PathEnemyShooting>().enabled = true;
        }
        if(gameObject.GetComponent<GolemLazerAttack>() != null)
        {
            gameObject.GetComponent<GolemLazerAttack>().enabled = true;
        }
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
                burnAnimation.SetActive(true);
                alreadyBurning = true;
            }
            UpdateHealth(-burnDPS);
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        burnAnimation.SetActive(false);
        alreadyBurning = false;
        yield break;
        // All Done!        
    }

    public IEnumerator Shock6S()
    {
        float i = 3f;
        while (i > 0)
        {
            if (!alreadyShocked)
            {
                alreadyShocked = true;
                shockAnimation.SetActive(true);
            }
            
            StartCoroutine(Root1S());
            UpdateHealth(-shockDPS);
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(2f);
        }
        shockAnimation.SetActive(false);
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

    public IEnumerator MiniStun()
    {
        var path = gameObject.GetComponent<Pathfinding.AIPath>();
        var originalSpeed = path.maxSpeed;
        float i = 1f;

        while (i > 0)
        {
            if (!alreadyStunned)
            {
                stunIndicator.SetActive(true);
                if (gameObject.GetComponent<PathEnemyShooting>() != null)
                {
                    gameObject.GetComponent<PathEnemyShooting>().enabled = false;
                }
                if (gameObject.GetComponent<GolemLazerAttack>() != null)
                {
                    gameObject.GetComponent<GolemLazerAttack>().enabled = false;
                }
                path.maxSpeed = 0f;
                alreadyStunned = true;
                
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(.4f);
        }
        stunIndicator.SetActive(false);
        if (gameObject.GetComponent<PathEnemyShooting>() != null)
        {
            gameObject.GetComponent<PathEnemyShooting>().enabled = true;
        }
        if (gameObject.GetComponent<GolemLazerAttack>() != null)
        {
            gameObject.GetComponent<GolemLazerAttack>().enabled = true;
        }
        path.maxSpeed = originalSpeed;
        alreadyStunned = false;
        yield break;
        // All Done!        
    }
}




