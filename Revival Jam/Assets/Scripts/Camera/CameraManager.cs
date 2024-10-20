using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    int index;
    int length;
    public RectTransform[] scenarios;

    private void OnEnable()
    {
        index = 0;
        length = scenarios.Length;
    }

    public void MoveLeft()
    {
        index--;
        Move(index);
    }

    public void MoveRight()
    {
        index++;
        Move(index);
    }

    public void Move(int index)
    {
        transform.position = scenarios[index % length].position;
    }
}
