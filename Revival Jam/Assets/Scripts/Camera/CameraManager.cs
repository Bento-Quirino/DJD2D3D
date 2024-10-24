using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  int index;
  int length;
  public Transform[] scenarios;

  private void OnEnable()
  {
    index = 0;
    length = scenarios.Length;
  }

  public void MoveLeft()
  {
    index--;
    if(index < 0) { index = length - 1; }

    Move(index);
  }

  public void MoveRight()
  {
    index++;
    if(index > length - 1) { index = 0; }
    Move(index);
  }

  public void Move(int index)
  {
    Vector3 pos = scenarios[index % length].position;
    pos.z = transform.position.z;
    transform.position = pos;
  }
}
