using UnityEngine;

/*No Unity uma classe ou um script, em geral, funcionam como componentes que para rodar, devem ser
adicionados a um GameObject, um objeto de cena do Unity.
Quando um componente é adicionado à um GameObject, esse GameObject passa a ter uma instância
desse componente, e ele fica listado no Inspector (na interface do Unity).
*/

[RequireComponent(typeof(CharacterController))]
public class Moviment : MonoBehaviour
{
  //Podemos acessar um component via código declarando uma referência para ele
  //e atribuindo uma chamada do GetComponent<>() a ele.
  //CharacterController é um componente usado para personagens 3D não baseados em física (ex. reação automática a colisão)
  CharacterController controller;

  //Vector3 porque o personagem pode se mover no espaço 3D (XYZ).
  //Velocidade vetorial
  Vector3 velocity;
  Vector3 direction;
  //rapidez
  float speed = 7.5f;

  void Awake()
  {
    //GetComponent<>() retorna o componente desejado, que está no GameObject que roda o código
    //que chama o GetComponent<>().
    controller = GetComponent<CharacterController>();
  }

  void Update()
  {
    //Chama (executa) o método de movimento a cada frame
    Move();
  }

  void Move()
  {
    //Algoritmo de Movimento
    //1 - ler comandos de movimento do jogador
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical"); //personagem ANDA no XZ e PULA no Y.

    //2 - construir direção com os comandos
    direction = new Vector3(x, 0, z);

    //3 - calcular deslocamento
    velocity = direction.normalized * speed * Time.deltaTime;

    //4 - Mover a partir do deslocamento
    controller.Move(velocity);
  }
}
