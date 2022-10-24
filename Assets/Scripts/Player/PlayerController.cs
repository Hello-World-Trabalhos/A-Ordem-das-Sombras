using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    public Player player;
    public Animator playerAnimator;
    FixedJoystick fixedJoystick;
    float input_x = 0;
    float input_y = 0;
    //public float speed = 2.5f;
    bool isWalking = false;
    SpriteRenderer sr;
    Rigidbody2D rb2;
    Vector2 movement = Vector2.zero;
    public Button btnAttack;

    void Start()
    {
        GameObject hud = GameObject.Find("UserInterface").transform.Find("Canvas")
            .transform.Find("Hud").gameObject;

        btnAttack = hud.transform.Find("Attack").GetComponent<Button>();

        btnAttack.onClick.AddListener(() => AtackPlayer());

        isWalking = false;
        fixedJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        sr = GetComponent<SpriteRenderer>();

        rb2 = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        //camera
        Vector3 newCamaraPosition = new Vector3();
        newCamaraPosition.x = gameObject.transform.position.x;
        newCamaraPosition.y = gameObject.transform.position.y;
        newCamaraPosition.z = ScenarioGenerationViewerConstants.Z_CAMERA_AXIS;
        Camera.main.transform.position = newCamaraPosition;
        Camera.main.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (fixedJoystick != null) {
            MovePlayer();
        }

        //AtackPlayer();
    }

    void MovePlayer()
    {
        //pegando os comandos de movimenta��o pelo teclado
        //input_x = Input.GetAxisRaw("Horizontal");
        //input_y = Input.GetAxisRaw("Vertical");

        input_x = fixedJoystick.Horizontal;
        input_y = fixedJoystick.Vertical;
        isWalking = (input_x != 0 || input_y != 0);

        movement = new Vector2(input_x, input_y);

        if (isWalking)
        {
            // movendo o objeto do personagem
            //var move = new Vector3(input_x, input_y, 0).normalized;
            //transform.position += move * speed * Time.deltaTime;

            //movendo a anima��o de run_right para a run_left
            if (input_x < 0)
            {
                sr.flipX = true;
            }
            if (input_x > 0)
            {
                sr.flipX = false;
            }
            //controlhando as anima��es
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
        }
        playerAnimator.SetBool("isWalking", isWalking);
    }

    public void AtackPlayer()
    {
        playerAnimator.SetTrigger("attack");
        player.entity.attackTimer = player.entity.coolDown;
        Attack();

    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movement * player.entity.speed * Time.fixedDeltaTime);
    }

    //private void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.transform.tag == "Enemy")
    //    {
    //        player.entity.target = null;
    //    }
    //}
    void Attack()
    {
        if (player.entity.target == null)
            return;

        Skeleton skeleton = player.entity.target.GetComponent<Skeleton>();

        if (skeleton.entity.dead)
        {
            player.entity.target = null;
            return;
        }

        float distance = Vector2.Distance(transform.position, player.entity.target.transform.position);

        if (distance <= player.entity.attackDistance)
        {
            int dmg = player.entity.damage;
            int enemyDef = player.entity.defence;
            int result = dmg - enemyDef;

            if (result < 0)
                result = 0;

            skeleton.entity.currentHealth -= result;
            //skeleton.entity.target = this.gameObject;
        }
    }
}
