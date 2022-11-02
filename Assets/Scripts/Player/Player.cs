using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public Entity entity;

    private Slider hpSliper;
    private Slider xpSliper;

    [Header("Exp")]
    public int currentExp;
    public int expBase;
    public int expLeft;
    public float expMod;
    [SerializeField] public GameObject regenerationFx;
    [SerializeField] public AudioClip regenerationSound;
    public Button btnPotion;

    /*[Header("Detection")]
    [SerializeField] private bool isShowDraw;
    [SerializeField] private float activeTimer = 0.1f;
    [SerializeField] private Transform pointDetection;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;*/

    [Header("Attack")]
    [SerializeField] private DetectionEnemy DetectionEnemy;
    private HealthEnemy healthEnemy;

    //private float timer;
    //private bool canDamage = true;
    public float timeLoader = 1.5f;

    void Start()
    {
        GameObject hud = GameObject.Find("UserInterface").transform.Find("Canvas")
            .transform.Find("Hud").gameObject;
        btnPotion = hud.transform.Find("Potion").GetComponent<Button>();
        btnPotion.onClick.AddListener(() => Regeneration());

        hpSliper = hud.transform.Find("HealthBar").transform.Find("HPSlider").GetComponent<Slider>();
        xpSliper = hud.transform.Find("LevelBar").transform.Find("XPSlider").GetComponent<Slider>();

        entity.currentHealth = entity.maxHealth;
        hpSliper.maxValue = entity.maxHealth;
        hpSliper.value = hpSliper.maxValue;

        entity.currentXP = 1;
        xpSliper.maxValue = entity.maxXP;
        xpSliper.value = 1 ;
    }

    void Awake()
    {
        gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (entity.isDead)
            return;
    }

    private void Update()
    {
        if (entity.isDead)
            return;

        if (entity.currentHealth <=0)
        {
            entity.currentHealth = 0;
            entity.isDead = true;
            Die();
        }


        hpSliper.value = entity.currentHealth;

        //if (Input.GetKeyDown(KeyCode.Space))
        //    entity.currentHealth -= 10;
    }

    public void GainExp(int amount)
    {
        currentExp += amount;
        if (currentExp >= expLeft)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        currentExp -= expLeft;
        entity.level++;

        float newExp = Mathf.Pow((float)expMod, entity.level);
        expLeft = (int)Mathf.Floor((float)expBase * newExp);
    }

    public void Regeneration()
    {
        entity.currentHealth = entity.maxHealth;

        //entity.entityAudio.PlayOneShot(regenerationSound);
        //Instantiate(regenerationFx, this.gameObject.transform); //.Find("RegenerationSound")
    }

    public void Die()
    {
        entity.isDead = true;
        entity.inCombat = false;
        entity.target = null;
        Invoke("DestroyPlayer",timeLoader);
        
    }

    private void CanAttack()
    {
        DetectionEnemy.gameObject.SetActive(true);
        DetectionEnemy.ResetTimer();
    }

    public void DestroyPlayer()
    {
        //Destroy(gameObject);
        SceneLoader.LoadMainMenu();
    }

    public void TakeDamage(int damage)
    {
        if (entity.currentHealth <= 0)
            return;

        entity.currentHealth -= damage;
        hpSliper.value -= damage;

    }

    #region Detection
    /*
    private void ActiveAttack()
    {
        if (Time.time > timer)
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTimer()
    {
        canDamage = true;
        timer = Time.time + activeTimer;
    }

    private void CheckDetection()
    {
        if (Physics2D.OverlapCircle(pointDetection.position, radius, layerMask))
        {
            healthEnemy = Physics2D.OverlapCircle(pointDetection.position, radius, layerMask).GetComponent<HealthEnemy>();
            if (healthEnemy == null)
                return;

            if (canDamage)
            {
                healthEnemy.TakeDamage(entity.damage);
                canDamage = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (isShowDraw)
        {
            if (pointDetection != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(pointDetection.position, radius);
            }
        }
    }*/
    #endregion
}
