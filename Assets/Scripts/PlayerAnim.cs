using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        onMove();
        onRun();
    }

    #region Movement
    void onMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            } 
                
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        //Verifica a direção (eixo x) que o objetos esta se movendo na cena, se maior que 0 mantem sem rotação. (Direita)
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        //Verifica a direção (eixo x) que o objetos esta se movendo na cena, se menor que 0 rotaciona em 180 graus o objeto. (Esquerda)
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void onRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
