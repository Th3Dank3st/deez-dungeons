using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //stats
    public bool leveledUp = false;
    private float IASBuffedDuration = 4f;
    private bool isIASBuffed = false;
    public Image IASBuffTimerBackground;
    public Image IASBuffTimer;
    private float basicCooldown1;
    private bool IASBuffed = false;
    public GameObject overloadGO;
    public GameObject overloadIndicator;
    public float critBonus;
    public float maxDamage;
    public float minDamage;
    public float test;
    public float cooldown;
    public float spellDamage;
    public float attackDamage;
    public float defense;
    public Text XPGoalText;
    public Text currentXPText;
    public HealthBar XPBar;
    public Text levelText;
    public GameObject stunEffect;
    public GameObject slowEffect;
    //unorganized
    private float currentLevel;
    private float currentXP;
    private float XPGoal;
    private float durationShockDash = 6;
    private bool isShockDashing = false;
    public Image shockDashTimer;
    public Image shockDashTimerBackground; 
    public GameObject shockDashIndicator;
    public Transform plasmaBlastFirepoint;
    public float dashExplosionDuration = 0.6f;
    private bool shockDashing = false;
    public GameObject dashExplosion;
    public GameObject playerPosition;
    public GameObject muzzleBlastAnimation;
    public float maxMana = 400f;
    private float currentMana;

    //global cooldown
    private bool globalCooldownActive = false;
    //ability 1 cooldown image
    public Image abilityImage1;
    public float cooldown1 = 3f;
    private bool isCooldown = false;
    //ability 2 cooldown image
    public Image abilityImage2;
    public float cooldown2 = 4f;
    private bool isCooldown2 = false;
    //ability 3 cooldown image
    public Image abilityImage3;
    public float cooldown3 = 6f;
    private bool isCooldown3 = false;
    //ability 4 cooldown image
    public Image abilityImage4;
    public float cooldown4 = 10f;
    private bool isCooldown4 = false;
    private bool alreadyStunned = false;
    private bool alreadyRooted = false;
    private bool alreadyChilled = false;
    //basic attack cooldown image
    public Image basicImage;
    private bool imageBasicCooldown = false;
    //status effects
    //chilled
    public Image HitEffectImageChilled;
    public Image HitEffectChilledBackground;
    private float cooldownChilled = 2f;
    private bool isCooldownChilled = false;
    //stunned
    public Image HitEffectImageStunned;
    public Image HitEffectStunnedBackground;
    public float cooldownStunned = 2f;
    private bool isCooldownStunned = false;
    //Rooted
    public Image HitEffectImageRoot;
    public Image HitEffectRootBackground;
    public float cooldownRoot = 2f;
    private bool isCooldownRoot = false;
    private bool muzzleBlast = false;

    //equipment
    public bool Armor1 = false;
    public bool Boots1 = false;
    public bool Ring1 = false;
    public bool Staff1 = false;
    public bool Amulet1 = false;
    public bool Gloves1 = false;
    public bool Head1 = false;


    public static PlayerMovement Instance;
    public float moveSpeed = 5f;
    public PlayerInputActions playerControls;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;                                                                    //INPUT CONTAINER, CONAINS VALUE CONTAINERS FOR AXIS X AND Y IN THE SCENE
    Vector2 mousePos;
    public Camera cam;
    private InputAction summon;
    private InputAction move;
    private InputAction fire;
    private InputAction basicAttack;
    private InputAction lunarSlash;
    private InputAction dash;
    private InputAction frozenOrb;
    private InputAction groundTarget;
    public Transform firePoint;
    public GameObject fireBulletPrefab;
    public GameObject lunarSlashPrefab;
    public float fireBulletForce = 20f;
    public float lunarSlashForce = 15f;

    //indicator
    private bool FOrbPending;
    public GameObject FOrbIndicator;
    public bool lunarPending;
    private bool groundTargetPending;
    public GameObject groundTargetIndicator;
    //public Texture2D cursorForGroundTarget;
    //public Texture2D cursorDefault;
    //public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private bool alreadyCasting = false;
    public Transform aoeIndicator;
    public GameObject aoeIndicatorObject;
    public GameObject infernoIndicatorObject;
    public Transform infernoIndicator;


    //summon
    private bool summonPending;
    private float summonCoolCounter;
    public float summonCooldown;
    public GameObject summonPrefab;

    //health
    public float maxHealth = 100f;
    private float currentHealth;
    //private float currentStamina;
    public HealthBar healthBarOverhead;
    public HealthBar staminaBarOverhead;
    public HealthBar healthBar;
    public HealthBar manaBar;
    public float regenAmount;
    private float healthCoolCounter;
    public float healthRegenCooldown;
    public float manaRegenAmount;
    private float manaCoolCounter;
    public float manaRegenCooldown;

    //ground target
    public GameObject go;
    private float groundTargetCoolCounter;
    public float groundTargetCooldown;


    //lunar slash
    private float lunarCoolCounter;
    public float lunarCooldown = 1f;
    public GameObject lunarIndicator;

    //Frozen Orb
    private float FireCoolCounter;
    public float FireCooldown;

    //basic attack
    private float basicCoolCounter;
    public float basicCooldown;
    public GameObject basicBulletPrefab;
    public float basicBulletForce = 10f;


    //dash 
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    private float dashCounter;
    private bool isInvincible = false;
    private int dashCharges = 2;
    private bool dashRecharging = false;
    public float shockDashSpeed;
    public float shockDashLength;

    private void Awake()
    {
        cooldown = 100f;
        spellDamage = 1f;
        attackDamage = 1f;
        defense = 1f;
        currentLevel = 1f;
        levelText.text = currentLevel.ToString();
        XPGoal = 1000;
        currentXP = 0;
        XPBar.SetHealth(currentXP);
        XPGoalText.text = XPGoal.ToString();
        currentXPText.text = currentXP.ToString();
        abilityImage4.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage1.fillAmount = 0;
        basicImage.fillAmount = 0;
        //Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
        Instance = this;
        playerControls = new PlayerInputActions();                               //PlayerInputActions = script generated by NEW INPUT SYSTEM when the c# option is checked for the PlayerInputActions file, we have to create a script alongside the input system file to be able to reference it in other scripts like this one. we then store the information that is collected by the PlayerInputActions script in the playerControls variable to use later
        activeMoveSpeed = moveSpeed; //this is for dash
        currentHealth = maxHealth;
        currentMana = maxMana;
        healthBar.SetMaxHealth(maxHealth);//this is for health        
        staminaBarOverhead.SetMaxHealth(dashCharges);//this is max stamina
        manaBar.SetMaxHealth(maxMana);
        healthBarOverhead.SetMaxHealth(maxHealth);
    }

    // WHEN YOU PRESS A BUTTON    
    private void OnEnable()
    {
        move = playerControls.Player.Move;                                              //Grabbing our input values that are being generated by PlayerInputActions script from the container we are storing them in (playerControls) and designating what value we wan't to use 
        move.Enable();                                                                  // Enabling that information to be accessed by the UPDATE method when the key is pressed down (thats what the OnEnable function is for in the first place)

        fire = playerControls.Player.Fire;
        fire.Enable();
        //fire.performed += Fire;

        lunarSlash = playerControls.Player.LunarSlash;
        lunarSlash.Enable();
        //lunarSlash.performed += LunarSlash;        --- moved this to update so i could add a cooldown.

        dash = playerControls.Player.Dash;
        dash.Enable();

        frozenOrb = playerControls.Player.FrozenOrb;
        frozenOrb.Enable();

        groundTarget = playerControls.Player.GroundTarget;
        groundTarget.Enable();

        summon = playerControls.Player.Summon;
        summon.Enable();

        basicAttack = playerControls.Player.BasicAttack;
        basicAttack.Enable();
    }

    //WHEN YOU RELEASE IT
    private void OnDisable()
    {
        move.Disable();                                                                 //tells the UPDATE method below that there is no more input once the key is released
        fire.Disable();
        lunarSlash.Disable();
        dash.Disable();
        frozenOrb.Disable();
        summon.Disable();
        basicAttack.Disable();
    }

    // Update is called once per frame (use this for input)
    void Update()
    {
        staminaBarOverhead.SetHealth(dashCharges);
        movement = move.ReadValue<Vector2>();                                           //NEW INPUT system ---- updating our vector2(information type) movement container with the values stored in the move container defined above, which gets information from PlayerInputActions. this information is updated once per frame, so we don't want to put the equation that tells the engine to move here, because it would change based on the users framerate, so we will call upon this data in FixedUpdate when we perform the equation caluclating our movespeed
        animator.SetFloat("Horizontal", movement.x);                                    // INPUT FOR ANIMATIONS (TELLS THE ANIMATOR WHICH ANIMATION TO USE FOR EACH DIRECTION
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);                              //TELLS THE ANIMATOR IF WE ARE MOVING
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());   // updates mouse position of the user in NEW INPUT SYSTEM
        aoeIndicator.position = mousePos;
        infernoIndicator.position = mousePos;
        overloadIndicator.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;

        //DASH
        if (playerControls.Player.Dash.triggered && !alreadyStunned)
        {
            if (dashCounter <= 0 && dashCharges >= 1)
            {
                activeMoveSpeed = dashSpeed;
                isInvincible = true;
                animator.SetBool("isRolling", true);
                dashCounter = dashLength;
            }
            if (shockDashing && currentMana > 5)
            {
                UpdateMana(-5);
                GameObject explosion = Instantiate(dashExplosion, playerPosition.transform.position, Quaternion.identity);
                Destroy(explosion, dashExplosionDuration);
                activeMoveSpeed = shockDashSpeed;
                isInvincible = true;
                animator.SetBool("isRolling", true);
                dashCounter = shockDashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                isInvincible = false;
                animator.SetBool("isRolling", false);
                StartCoroutine(DashChargeCooldown());
                dashCharges--;
                staminaBarOverhead.SetHealth(dashCharges);
            }
        }

        //Passive Regen
        if (currentHealth < maxHealth)
        {
            if (healthCoolCounter <= 0)
            {
                UpdateHealth(regenAmount);
                healthCoolCounter = healthRegenCooldown;
            }
        }

        if (healthCoolCounter > 0)
        {
            healthCoolCounter -= Time.deltaTime;
        }

        //Passive Mana Regen
        if (currentMana < maxMana)
        {
            if (manaCoolCounter <= 0)
            {
                UpdateMana(manaRegenAmount);
                manaCoolCounter = manaRegenCooldown;
            }
        }

        if (manaCoolCounter > 0)
        {
            manaCoolCounter -= Time.deltaTime;
        }

        //SKILLS_____________________________________________________________________________________

        //global cooldown
        if (alreadyCasting)
        {
            StartCoroutine(GlobalCooldown());
        }

        //Frozen Orb
        if (playerControls.Player.FrozenOrb.triggered && !alreadyCasting && !alreadyStunned && !globalCooldownActive)
        {
            if (FireCoolCounter <= 0 && currentMana >= 20)
            {
                UpdateMana(-30);
                FOrbIndicator.SetActive(true);
                FOrbPending = true;
                alreadyCasting = true;
            }

        }

        if (playerControls.Player.Fire.triggered && FOrbPending && !alreadyStunned)
        {
            animator.SetTrigger("Attack");
            GameObject bullet = Instantiate(fireBulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * fireBulletForce, ForceMode2D.Impulse);
            FireCoolCounter = FireCooldown;
            FOrbIndicator.SetActive(false);
            abilityImage2.fillAmount = 1;
            isCooldown2 = true;
            alreadyCasting = false;
            FOrbPending = false;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }

        if (FireCoolCounter > 0)
        {
            FireCoolCounter -= Time.deltaTime;
        }

        //Inferno
        /* if (playerControls.Player.GroundTarget.triggered && !alreadyCasting && !alreadyStunned && !globalCooldownActive)
         {

             if (groundTargetCoolCounter <= 0 && currentMana >= 20)
             {
                 UpdateMana(-20);
                 //Cursor.SetCursor(cursorForGroundTarget, hotSpot, cursorMode);
                 infernoIndicatorObject.SetActive(true);
                 alreadyCasting = true;
                 groundTargetPending = true;
             }
         }

         if (playerControls.Player.Fire.triggered && groundTargetPending && !alreadyStunned)
         {
             animator.SetTrigger("Attack");
             GameObject newEnemy = Instantiate(go, mousePos, Quaternion.identity);
             Destroy(newEnemy, 4f);
             groundTargetCoolCounter = groundTargetCooldown;
             //Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
             abilityImage1.fillAmount = 1;
             isCooldown = true;
             groundTargetPending = false;
             alreadyCasting = false;
             infernoIndicatorObject.SetActive(false);
         }

         if (isCooldown)
         {
             abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
             if (abilityImage1.fillAmount <= 0)
             {
                 abilityImage1.fillAmount = 0;
                 isCooldown = false;
             }
         }

         if (groundTargetCoolCounter > 0)
         {
             groundTargetCoolCounter -= Time.deltaTime;
         }
        */

        //Overload (electric explosion thingy)
        if (playerControls.Player.GroundTarget.triggered && !alreadyCasting && !alreadyStunned && !globalCooldownActive)
        {

            if (groundTargetCoolCounter <= 0 && currentMana >= 20)
            {
                UpdateMana(-20);
                //Cursor.SetCursor(cursorForGroundTarget, hotSpot, cursorMode);
                overloadIndicator.SetActive(true);
                alreadyCasting = true;
                groundTargetPending = true;
            }
        }

        if (playerControls.Player.Fire.triggered && groundTargetPending && !alreadyStunned)
        {
            animator.SetTrigger("Attack");
            GameObject newEnemy = Instantiate(overloadGO, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(newEnemy, .5f);
            groundTargetCoolCounter = groundTargetCooldown;
            //Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
            abilityImage1.fillAmount = 1;
            //transform.position = new Vector2(gameObject.GetComponent<Transform>().position.x/* + distance*/, gameObject.GetComponent<Transform>().position.y);            
            isCooldown = true;
            groundTargetPending = false;
            alreadyCasting = false;
            overloadIndicator.SetActive(false);
            StartCoroutine(AttackSpeedBuff());
        }

        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }

        if (groundTargetCoolCounter > 0)
        {
            groundTargetCoolCounter -= Time.deltaTime;
        }

        //LunarSlash
        if (playerControls.Player.LunarSlash.triggered && !alreadyCasting && !alreadyStunned && !globalCooldownActive)
        {
            if (lunarCoolCounter <= 0 && currentMana >= 40)
            {
                UpdateMana(-40);
                alreadyCasting = true;
                lunarIndicator.SetActive(true);
                lunarPending = true;
            }

        }

        if (playerControls.Player.Fire.triggered && lunarPending && !alreadyStunned)
        {
            animator.SetTrigger("Attack");
            GameObject bullet = Instantiate(lunarSlashPrefab, plasmaBlastFirepoint.position, plasmaBlastFirepoint.rotation);
            //bullet.GetComponent<PlasmaAoeExplosion>().damage *= spellDamage;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * lunarSlashForce, ForceMode2D.Impulse);
            lunarCoolCounter = lunarCooldown;
            lunarIndicator.SetActive(false);
            abilityImage3.fillAmount = 1;
            isCooldown3 = true;
            lunarPending = false;
            alreadyCasting = false;
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }

        if (lunarCoolCounter > 0)
        {
            lunarCoolCounter -= Time.deltaTime;
        }

        //ShockBlast//teleport//ULTIMATE
        if (playerControls.Player.Summon.triggered && !alreadyCasting && !alreadyStunned && !globalCooldownActive)
        {
            if (summonCoolCounter <= 0 && currentMana >= 50)   //summonCoolCounter
            {
                UpdateMana(-50);
                //Cursor.SetCursor(cursorForGroundTarget, hotSpot, cursorMode);   //cursorForSummon
                aoeIndicatorObject.SetActive(true);
                alreadyCasting = true;
                summonPending = true;      //summonPending = true;
            }
        }

        if (playerControls.Player.Fire.triggered && summonPending && !alreadyStunned)   //&& summonPending
        {
            StartCoroutine(ShockDashing());
            animator.SetTrigger("Attack");
            GameObject summon = Instantiate(summonPrefab, mousePos, Quaternion.identity);
            //summon.GetComponent<ShockBlastScript>().damage *= spellDamage;
            Destroy(summon, 0.3f);
            summonCoolCounter = summonCooldown;
            //Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
            abilityImage4.fillAmount = 1;
            transform.position = new Vector2(mousePos.x/* + distance*/, mousePos.y);
            isCooldown4 = true;            
            summonPending = false;
            alreadyCasting = false;
            aoeIndicatorObject.SetActive(false);
            
        }

        if (isCooldown4)
        {
            abilityImage4.fillAmount -= 1 / cooldown4 * Time.deltaTime;
            if (abilityImage4.fillAmount <= 0)
            {
                abilityImage4.fillAmount = 0;
                isCooldown4 = false;
            }
        }

        if (summonCoolCounter > 0)
        {
            summonCoolCounter -= Time.deltaTime;
        }


        //basic attack
        if (playerControls.Player.BasicAttack.triggered && !alreadyStunned && !alreadyCasting && !globalCooldownActive)
        {
            if (basicCoolCounter <= 0)
            {
                StartCoroutine(MuzzleBlast());
                animator.SetTrigger("Attack");
                GameObject bullet = Instantiate(basicBulletPrefab, firePoint.position, firePoint.rotation);
                var attack = (attackDamage * .01f) + 1f;
                bullet.GetComponent<Bullet>().damage *= attack;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * basicBulletForce, ForceMode2D.Impulse);
                basicCoolCounter = basicCooldown;
                basicImage.fillAmount = 1;
                imageBasicCooldown = true;
            }
        }

        if (imageBasicCooldown)
        {
            basicImage.fillAmount -= 1 / basicCooldown * Time.deltaTime;
            if (basicImage.fillAmount <= 0)
            {
                basicImage.fillAmount = 0;
                imageBasicCooldown = false;
            }
        }

        if (basicCoolCounter > 0)
        {
            basicCoolCounter -= Time.deltaTime;
        }































        //status effect cooldown timer indicators__________________________________________________________________

        if (isIASBuffed)
        {
            IASBuffTimer.fillAmount -= 1 / IASBuffedDuration * Time.deltaTime;

            if (IASBuffTimer.fillAmount <= 0)
            {
                IASBuffTimer.fillAmount = 0;
                isIASBuffed = false;
                IASBuffTimer.gameObject.SetActive(false);
                IASBuffTimerBackground.gameObject.SetActive(false);
            }
        }

        //is shockdashing
        if (isShockDashing)
        {
            shockDashTimer.fillAmount -= 1 / durationShockDash * Time.deltaTime;

            if (shockDashTimer.fillAmount <= 0)
            {
                shockDashTimer.fillAmount = 0;
                isShockDashing = false;
                shockDashTimer.gameObject.SetActive(false);
                shockDashTimerBackground.gameObject.SetActive(false);
            }
        }
        //chilled
        if (isCooldownChilled)
        {
            HitEffectImageChilled.fillAmount -= 1 / cooldownChilled * Time.deltaTime;

            if (HitEffectImageChilled.fillAmount <= 0)
            {
                HitEffectImageChilled.fillAmount = 0;
                isCooldownChilled = false;
                HitEffectImageChilled.gameObject.SetActive(false);
                HitEffectChilledBackground.gameObject.SetActive(false);
            }
        }

        //rooted
        if (isCooldownRoot)
        {
            HitEffectImageRoot.fillAmount -= 1 / cooldownRoot * Time.deltaTime;

            if (HitEffectImageRoot.fillAmount <= 0)
            {
                HitEffectImageRoot.fillAmount = 0;
                isCooldownRoot = false;
                HitEffectImageRoot.gameObject.SetActive(false);
                HitEffectRootBackground.gameObject.SetActive(false);
            }
        }

        //stunned
        if (isCooldownStunned)
        {
            HitEffectImageStunned.fillAmount -= 1 / cooldownStunned * Time.deltaTime;

            if (HitEffectImageStunned.fillAmount <= 0)
            {
                HitEffectImageStunned.fillAmount = 0;
                isCooldownStunned = false;
                HitEffectImageStunned.gameObject.SetActive(false);
                HitEffectStunnedBackground.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Chill
        if (other.gameObject.tag == "ChillEnemyProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyChilled && !isInvincible)
            {
                StartCoroutine(Chilled2S());
            }
        }

        //Root(immobilize)
        if (other.gameObject.tag == "RootEnemyProjectile")
        {
            if (!alreadyRooted && !isInvincible)
            {
                StartCoroutine(Root2S());
            }
        }

        //Stun
        if (other.gameObject.tag == "StunEnemyProjectile")   // the tag of the projectile that i want this effect to be triggered on
        {
            if (!alreadyStunned && !isInvincible)
            {
                StartCoroutine(Stunned2S());
            }
        }
    }

    //chill
    public IEnumerator Chilled2S()
    {
        var path = gameObject.GetComponent<PlayerMovement>();
        var originalSpeed = path.activeMoveSpeed;
        float i = 2f;
        while (i > 0)
        {
            if (!alreadyChilled)
            {
                slowEffect.SetActive(true);
                HitEffectImageChilled.gameObject.SetActive(true);
                HitEffectChilledBackground.gameObject.SetActive(true);
                path.activeMoveSpeed *= 0.5f;
                HitEffectImageChilled.fillAmount = 1;
                alreadyChilled = true;
                isCooldownChilled = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        slowEffect.SetActive(false);
        activeMoveSpeed = originalSpeed;
        alreadyChilled = false;
        // All Done!        
    }

    //Root
    public IEnumerator Root2S()
    {
        float i = 2f;
        while (i > 0)
        {
            if (!alreadyRooted)
            {
                HitEffectImageRoot.gameObject.SetActive(true);
                HitEffectRootBackground.gameObject.SetActive(true);
                move.Disable();
                HitEffectImageRoot.fillAmount = 1;
                alreadyRooted = true;
                isCooldownRoot = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        move.Enable();
        alreadyRooted = false;
        // All Done!        
    }

    //Stun
    public IEnumerator Stunned2S()
    {
        float i = 1f;
        while (i > 0)
        {
            if (!alreadyStunned)
            {
                stunEffect.SetActive(true);
                HitEffectImageStunned.gameObject.SetActive(true);
                HitEffectStunnedBackground.gameObject.SetActive(true);
                move.Disable();
                HitEffectImageStunned.fillAmount = 1;
                alreadyStunned = true;
                isCooldownStunned = true;
            }
            // ^^Do something for i ammount of times times^^
            i--;
            yield return new WaitForSeconds(1f);
        }
        stunEffect.SetActive(false);
        move.Enable();
        alreadyStunned = false;
        // All Done!        
    }

    //called 50 times per second     (use this for output)
    void FixedUpdate()
    {                                           //|NEWDASH BELOW|
        rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);    //accessing our "moveSpeed" float(data container) which we set at the top, and accessing our "movement" data which we collect from the user once per frame(look in the void Update method above), so that we can perform the equation for movement direction and speed. (our Vector2 x,y value container "movement" for direction) (our float container "moveSpeed" for speed), and send the result of the equation off to the rigidbody2d that we named rb at the top, and using the MovePosition function possessed by the game engine (unity) to move our player's rigidbody that we assigned it in the engine.
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void UpdateXP(float experience)
    {
        currentXP += experience;
        XPBar.SetHealth(currentXP);
        currentXPText.text = currentXP.ToString();
        //experiencebar.sethealth(currentXP)
        if (currentXP >= XPGoal)
        {
            //reference inventory, drag and drop inventory in editor, getcomponentinchild and find the inventoryitemcontrollers and update the stats
            currentLevel++;
            levelText.text = currentLevel.ToString();
            XPGoal *= 1.4f;            
            maxHealth += 5;
            maxMana += 3;
            basicCooldown -= 0f;
            regenAmount += 0f;
            manaRegenAmount += 0.2f;
            currentHealth = maxHealth;
            currentMana = maxMana;
            healthBar.SetHealth(currentHealth);
            healthBarOverhead.SetHealth(currentHealth);
            manaBar.SetHealth(currentMana);
            currentXP = 0;
            XPBar.SetMaxHealth(XPGoal);
            XPBar.SetHealth(currentXP);
            currentXPText.text = currentXP.ToString();
            XPGoalText.text = XPGoal.ToString();
            leveledUp = true;
        }
    }

    public void UpdateHealth(float damage)
    {
        if (isInvincible) return;
        var totalDefense = 1f - (defense * 0.01f);
        currentHealth += (damage * totalDefense);
        healthBar.SetHealth(currentHealth);
        healthBarOverhead.SetHealth(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            FindObjectOfType<LevelManager>().Restart();
        }
    }

    public void UpdateMana(float amount)
    {
        currentMana += amount;
        manaBar.SetHealth(currentMana);

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        else if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }

    //Passive Regen

        

IEnumerator DashChargeCooldown()
    {
        while (dashCharges < 3)         //assuming i have something in update that does dashCharges--;
        {
            if (!dashRecharging)        // set dash recharging to true, wait 10s
            {
                dashRecharging = true;
                yield return new WaitForSeconds(7f);
            }
            if (dashRecharging)             //after 10 seconds one dash charge is added, dash recharging set back to false, keeping the loop going untill dashCharges = 3
            {
                dashCharges++;
                dashRecharging = false;
                yield break;
            }
        }
    }

    IEnumerator GlobalCooldown()
    {
        int b = 1;
        while (b > 0)
        {
            if (!globalCooldownActive)
            {
                globalCooldownActive = true;
            }
            b--;
            yield return new WaitForSeconds(1f);
        }
        globalCooldownActive = false;
    }

    IEnumerator MuzzleBlast()
    {
        int T = 1;
        while (T > 0)
        {
            if (!muzzleBlast)
            {
                muzzleBlastAnimation.SetActive(true);
                muzzleBlast = true;
            }
            T--;
            yield return new WaitForSeconds(.1f);
        }
        muzzleBlast = false;
        muzzleBlastAnimation.SetActive(false);
    }

    IEnumerator ShockDashing()
    {
        int o = 1;
        while (o > 0)
        {

            if (!shockDashing)
            {
                shockDashTimer.gameObject.SetActive(true);
                shockDashTimerBackground.gameObject.SetActive(true);               
                shockDashIndicator.SetActive(true);
                isShockDashing = true;
                shockDashing = true;
                shockDashTimer.fillAmount = 1;
            }
            o--;
            yield return new WaitForSeconds(6f);
        }
        shockDashIndicator.SetActive(false);
        shockDashing = false;
    }

    IEnumerator AttackSpeedBuff()
    {
        int k = 1;
        while (k > 0)
        {
            if (!IASBuffed)
            {
                basicCooldown1 = basicCooldown;
                basicCooldown *= 0.5f;
                IASBuffed = true;
                isIASBuffed = true;
                IASBuffTimer.gameObject.SetActive(true);
                IASBuffTimerBackground.gameObject.SetActive(true);
                IASBuffTimer.fillAmount = 1;
            }
            k--;
            yield return new WaitForSeconds(4f);
        }
        basicCooldown = basicCooldown1;
        IASBuffed = false;
    }
}