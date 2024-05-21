using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    //Nesse caso, representa o 'transform' do jogador
    public Transform target;
    readonly float sphereRadius = 0.5f;

    void InVision()
    {
        Vector3 direction = 
            (target.position - transform.position).normalized;
        
        //Verificar se o jogador est� no campo de vis�o
        
        //RaycastHit � um struct que guarda informa��o
        //de colis�o DE UM RAYCAST E FAM�LIA
        RaycastHit hit;
        Physics.SphereCast(transform.position,
            sphereRadius, direction, out hit);
        
        //Caso o COLLIDER do RaycastHit seja
        //NULO, o raycast N�O COLIDIU com algu�m
        if(hit.collider != null)
        {
            //Se o objeto atingido foi o Player
            //(possui a tag 'Player'
            if(hit.collider.CompareTag("Player"))
            {
                //Mover();

                //if(InAction())
                //{ Atacar(); }
            }

            //Se o IF acima for FALSO, o jogador
            //N�O ESTA NO CAMPO DE VIS�O
        }
    }

    readonly float detectionRange = 1600f;
    void InRange()
    {
        Vector3 v = (target.position - transform.position);
        float sqrDistance = v.sqrMagnitude;

        //Se a distancia entre o inimigo e o jogador
        //for MENOR OU IGUAL que a
        //CAPACIDADE DE DETEC��O
        //ent�o o inimigo pode agir
        if(sqrDistance <= detectionRange)
        {
            //Mover();
        }
    }

    readonly float actionRange = 800f;
    void InAction()
    {
        Vector3 v = (target.position - transform.position);
        float sqrDistance = v.sqrMagnitude;
        if (sqrDistance <= actionRange)
        {
            //Atacar();
        }
    }
}
