using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdle : MonoBehaviour
{
    void Awake()
    {
        /*
            Para acessar um componente de um objeto via código
            é necessário usar o método GetComponent<>()
            Por exemplo:
            MeshRenderer rend = GetComponent<MeshRenderer>();

            Uma exceção é o componente Transform, o qual
            o Unity disponibiliza automaticamente no código
            pela propriedade/atributos 'transform', para que
            o programador não precise usar GetComponent no Transform.

            Para acessar atributos de um componente ou qualquer
            objeto, é necessário utilizar o '.':
             <nome do objeto>.<nome do atributo>
        */
    }

    //'=' deve ser lido como:
    //elemento a esquerda recebe elemento a direita

    float yRotation = 0; //guarda valor atual da rotação do objeto
    float angularSpeed = 5f; //velocidade de rotação

    // Update is called once per frame
    void Update()
    {
        //Seta a rotação em EulerAngles a cada frame
        transform.eulerAngles = new Vector3(0, yRotation, 0);
        //aumenta a rotação
        yRotation += angularSpeed * Time.deltaTime;
    }
}
