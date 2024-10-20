using UnityEngine;
using System;
using System.Collections;
using Utility.EasingEquations;

public class EasingControl : MonoBehaviour
{
  //define como o controlador se atualiza
  public enum TimeType
  {
    //update normal, incrementando no passo do Time.deltaTime.
    //tempo para se a escala de tempo for zerada
    Normal = 0,
    //não para mesmo com a escala de tempo zerada
    Real,
    //Atualiza junto com o tempo do motor de física
    Fixed
  };

  //Indica o estado do controlador
  public enum PlayState
  {
    Stopped = 0,
    Paused,
    Playing,
    Reversing
  }

  //Indica se ao fim da animação, ela é resetada, ou as alterações permanecem
  public enum EndBehaviour
  {
    Constant,
    Reset
  }

  //Indica se ao fim do loop, ele é repetido ou ocorre de forma reversa
  public enum LoopType
  {
    Repeat,
    PingPong
  }

  public event EventHandler updateEvent;
  public event EventHandler stateChangeEvent;
  public event EventHandler completedEvent;
  public event EventHandler loopedEvent;

  public TimeType timeType = TimeType.Normal;
  public PlayState playState { get; private set; }
  public PlayState previousState { get; private set; }
  public EndBehaviour endBehaviour = EndBehaviour.Constant;
  public LoopType loopType = LoopType.Repeat;
  public bool IsPlaying
  {
    get
    {
      return playState == PlayState.Playing ||
        playState == PlayState.Reversing;
    }
  }

  public Vector3 startValue = Vector3.zero;
  public Vector3 endValue = Vector3.zero;
  public float duration = 0;
  public int loopCount = 0;
  public Func<Vector3, Vector3, float, Vector3> equation = EasingVector3Equations.Linear;

  //possui alcance de zero ao valor da duração determinada
  public float currentTime { get; private set; }
  //valor calculado pela EasingEquations a qualquer momento
  public Vector3 currentValue { get; private set; }
  //quantidade de mudança no 'value' desde o ultimo frame
  public Vector3 currentOffSet { get; private set; }
  //quantas vezes a animação rodou em loop
  public int loops { get; private set; }

  public void OnEnable()
  {
    Resume();
  }

  public void OnDisable()
  {
    Pause();
  }

  public void Play()
  {
    SetPlayState(PlayState.Playing);
  }

  public void Pause()
  {
    SetPlayState(PlayState.Paused);
  }

  public void Resume()
  {
    SetPlayState(previousState);
  }

  public void Reverse()
  {
    SetPlayState(PlayState.Reversing);
  }

  public void Stop()
  {
    SetPlayState(PlayState.Stopped);
    loops = 0;
    if (endBehaviour == EndBehaviour.Reset)
      SeekToBeginning();
  }

  public void SeekToTime(float time)
  {
    currentTime = Mathf.Clamp01(time / duration);
    Vector3 newValue = (endValue - startValue) * currentTime + startValue;
    currentOffSet = newValue - currentValue;
    currentValue = newValue;

    if (updateEvent != null)
      updateEvent(this, EventArgs.Empty);
  }

  public void SeekToBeginning()
  {
    SeekToTime(0);
  }

  public void SeekToEnd()
  {
    SeekToTime(duration);
  }

  public void SetPlayState(PlayState target)
  {
    if (playState == target)
      return;
    previousState = playState;
    playState = target;

    if (stateChangeEvent != null)
      stateChangeEvent(this, EventArgs.Empty);
    StopCoroutine("Ticker");
    if (IsPlaying)
      StartCoroutine("Ticker");
  }

  IEnumerator Ticker()
  {
    while (true)
    {
      switch (timeType)
      {
        case TimeType.Normal:
          yield return new WaitForEndOfFrame();
          Tick(Time.deltaTime);
          break;
        case TimeType.Real:
          yield return new WaitForEndOfFrame();
          Tick(Time.unscaledDeltaTime);
          break;
        default: // Fixed
          yield return new WaitForFixedUpdate();
          Tick(Time.fixedDeltaTime);
          break;
      }
    }
  }

  void Tick(float time)
  {
    bool finished = false;
    if (playState == PlayState.Playing)
    {
      currentTime = Mathf.Clamp01(currentTime + (time / duration));
      finished = Mathf.Approximately(currentTime, 1.0f);
    }
    else // Reversing
    {
      currentTime = Mathf.Clamp01(currentTime - (time / duration));
      finished = Mathf.Approximately(currentTime, 0.0f);
    }

    Vector3 frameValue = Vector3.Scale((endValue - startValue),(equation(Vector3.zero, Vector3.one, currentTime))) + startValue;

    currentOffSet = frameValue - currentValue;
    currentValue = frameValue;

    if (updateEvent != null)
      updateEvent(this, EventArgs.Empty);

    if (finished)
    {
      ++loops;
      if (loopCount < 0 || loopCount >= loops)
      {
        if (loopType == LoopType.Repeat)
          SeekToBeginning();
        else // PingPong
          SetPlayState(playState == PlayState.Playing ? PlayState.Reversing : PlayState.Playing);

        if (loopedEvent != null)
          loopedEvent(this, EventArgs.Empty);
      }
      else
      {
        if (completedEvent != null)
          completedEvent(this, EventArgs.Empty);

        Stop();
      }
    }
  }
}
