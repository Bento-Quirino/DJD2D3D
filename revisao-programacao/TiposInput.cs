using UnityEngine;

public class TiposInput : MonoBehaviour
{
  void Update()
  {
    //1º
    /*A forma mais fácil de ler os comandos do jogador é através dos eixos (Axis), usando o método
    Input.GetAxis(). Os eixos existentes estão definidos no Edit -> Project Settings -> Input Manager.
    Esse método retorna valores entre 1.0 e -1.0.
    */
    //O eixo "Horizontal" está definino do Input Manager e mapeado para as teclas A, D, Left e Right.
    //Enquanto o jogador estiver pressionando A/left, 'x' receberá -1.
    //Enquanto o jogador estiver pressionando D/Right, 'x' receberá 1.
    //Caso todas estejam soltas, 'x' receberá 0.
    float x = Input.GetAxis("Horizontal");

    //2º
    /*Outra forma de ler os comandos é ler teclas específicas. Nesse caso existem o grupo de métodos
    Input.GetKey(), Input.GetKeyDown() e Input.GetKeyUp(). Eles retornam VERDADEIRO sempre que uma tecla é pressionada.
      Para identificar qual tecla é pressionada, deve ser passado seu código por parâmetro através do enumerador
    'KeyCode'.
    */

    //Input.GetKey() retorna verdadeiro ENQUANTO uma tecla está pressionada
    if(Input.GetKey(keyCode.Q))
    { transform.Rotate(0, -5, 0); }

    //Input.GetKeyDown() retorna verdadeiro UMA VEZ quando uma tecla é pressionada. Para retornar verdadeiro novamento
    //é necessário soltar a tecla e pressiona-la novamente.
    if(Input.GetKeyDown(keyCode.E))
    { transform.Rotate(0, 5, 0); }

    //Input.GetKeyUp() retorna verdadeiro UMA VEZ quando uma tecla está pressionada e é solta. Para retornar verdadeiro
    //novamente é necessário pressionar a tecla e solta-la novamente.
    if(Input.GetKeyUp(keyCode.Space))
    { transform.Translate(0, 5, 0); }

    //3º
    /*É possível também ler botões do mouse usando Input.GetMouseButton(). Esse método é na verdade um grupo de métodos
    e funciona igual ao Input.GetKey()*/

    //código '0' representa o botão esquerdo
    if(Input.GetMouseButtom(0))
    { transform.Rotate(0, -5, 0); }

    //código '1' representa o botão direito
    if(Input.GetMouseButtomDown(1))
    { transform.Rotate(0, 5, 0); }
  }
}
