using UnityEngine;
using System;
using Utility.EasingEquations;

/*Exemplo de uso
float value = EasingEquations.EaseInOutQuad(start, end, (time / duration));
transform.position = new Vector3(value, 0, 0);
*/

public class Cube : MonoBehaviour
{
  EasingControl control;

  public void Start()
  {
    control = gameObject.AddComponent<EasingControl>();
    /*control.startValue = -5;
    control.endValue = 7;*/
    control.startValue = transform.position;
    control.endValue = -transform.position;
    control.duration = 3;
    control.loopCount = -1; // inifinite looping
    control.loopType = EasingControl.LoopType.PingPong;
    control.equation = EasingVector3Equations.EaseInOutElastic;
    control.updateEvent += OnUpdateEvent;
    control.Play();
  }

  public void OnUpdateEvent(object sender, EventArgs e)
  {
    //transform.localPosition = new Vector3(control.currentValue, control.currentValue, 0);
    transform.localPosition = new Vector3(control.currentValue.x,
                              control.currentValue.y, control.currentValue.z);
  }
}


