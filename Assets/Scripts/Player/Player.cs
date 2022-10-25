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
    [SerializeField] private GameObject regenerationFx;
    [SerializeField] private AudioClip regenerationSound;
    public Button btnPotion;

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

    private void Update()
    {
        hpSliper.value = entity.currentHealth;

        if (Input.GetKeyDown(KeyCode.Space))
            entity.currentHealth -= 10;
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
}
