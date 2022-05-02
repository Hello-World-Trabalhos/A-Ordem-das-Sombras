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

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        fixedJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        //pegando os comandos de movimenta��o pelo teclado
        //input_x = Input.GetAxisRaw("Horizontal");
        //input_y = Input.GetAxisRaw("Vertical");

        //pegando os comandos de movimenta��o pelo joystick
        input_x = fixedJoystick.Horizontal;
        input_y = fixedJoystick.Vertical;
        isWalking = (input_x != 0 || input_y != 0);

        if(isWalking)
        {
            // movendo o objeto do personagem
            var move = new Vector3(input_x, input_y, 0).normalized;
            transform.position += move * speed * Time.deltaTime;

            //controlhando as anima��es
            playerAnimator.SetFloat("input_x", input_x);
            playerAnimator.SetFloat("input_y", input_y);
        }
        playerAnimator.SetBool("isWalking", isWalking);

        if(Input.GetButtonDown("Fire1"))
        {
            playerAnimator.SetTrigger("attack");
        }
    }
}
