using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    FixedJoystick fixedJoystick;
    float input_x = 0;
    float input_y = 0;
    public float speed = 2.5f;
    bool isWalking = false;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        fixedJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        AtackPlayer();
    }

    void MovePlayer()
    {
        //pegando os comandos de movimentação pelo teclado
        //input_x = Input.GetAxisRaw("Horizontal");
        //input_y = Input.GetAxisRaw("Vertical");

        input_x = fixedJoystick.Horizontal;
        input_y = fixedJoystick.Vertical;
        isWalking = (input_x != 0 || input_y != 0);

        if (isWalking)
        {
            // movendo o objeto do personagem
            var move = new Vector3(input_x, input_y, 0).normalized;
            transform.position += move * speed * Time.deltaTime;

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

    void AtackPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimator.SetTrigger("attack");
        }
    }
}
