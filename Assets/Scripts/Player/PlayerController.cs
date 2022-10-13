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

    // Start is called before the first frame update
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
        //pegando os comandos de movimentação pelo teclado
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

            //movendo a animação de run_right para a run_left
            if (input_x < 0)
            {
                sr.flipX = true;
            }
            if (input_x > 0)
            {
                sr.flipX = false;
            }
            //controlhando as animações
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
        }
        playerAnimator.SetBool("isWalking", isWalking);
    }

    public void AtackPlayer()
    {
        playerAnimator.SetTrigger("attack");
    }

    private void FixedUpdate()
    {
        rb2.MovePosition(rb2.position + movement * player.entity.speed * Time.fixedDeltaTime);
    }
}
