using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdle : MonoBehaviour
{
    void Awake()
    {
        /*
            Para acessar um componente de um objeto via c�digo
            � necess�rio usar o m�todo GetComponent<>()
            Por exemplo:
            MeshRenderer rend = GetComponent<MeshRenderer>();

            Uma exce��o � o componente Transform, o qual
            o Unity disponibiliza automaticamente no c�digo
            pela propriedade/atributos 'transform', para que
            o programador n�o precise usar GetComponent no Transform.

            Para acessar atributos de um componente ou qualquer
            objeto, � necess�rio utilizar o '.':
             <nome do objeto>.<nome do atributo>
        */
    }

    //'=' deve ser lido como:
    //elemento a esquerda recebe elemento a direita

    float yRotation = 0; //guarda valor atual da rota��o do objeto
    float angularSpeed = 5f; //velocidade de rota��o

    // Update is called once per frame
    void Update()
    {
        //Seta a rota��o em EulerAngles a cada frame
        transform.eulerAngles = new Vector3(0, yRotation, 0);
        //aumenta a rota��o
        yRotation += angularSpeed * Time.deltaTime;
    }
}
