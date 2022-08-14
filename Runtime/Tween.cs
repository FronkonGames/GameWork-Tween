////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Martin Bustos @FronkonGames <fronkongames@gmail.com>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of
// the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using FronkonGames.GameWork.Foundation;

namespace FronkonGames.GameWork.Modules.Tween
{
  /// <summary>
  /// Tween operation. If it is created manually, Update() must be called.
  /// </summary>
  public class Tween<T> : ITween<T> where T : struct
  {
    /// <summary>
    /// Current status of Tween operation.
    /// </summary>
    public TweenState State { get; private set; } = TweenState.Finished;

    public bool IsOwned { get; private set; }
    
    /// <summary>
    /// Easing function.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public EasingFunction Easing { get; set; } = Linear.InOut;

    /// <summary>
    /// Current value.
    /// </summary>
    public T Value { get; private set; }

    /// <summary>
    /// Initial value.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public T ValueStart { get; set; }

    /// <summary>
    /// Final value.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public T ValueEnd { get; set; }

    /// <summary>
    /// Tween operation progress (0, 1).
    /// </summary>
    public float Progress { get; private set; }

    /// <summary>
    /// Executions counter.
    /// </summary>
    public int ExecutionCount { get; private set; }

    /// <summary>
    /// Execution mode.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public TweenExecution Execution { get; set; } = TweenExecution.Once;

    /// <summary>
    /// Time that the operation takes.
    /// </summary>
    public float Time { get; private set; }

    /// <summary>
    /// Time to execute the operation.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public float Duration { get; set; }

    /// <summary>
    /// Progress callback.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Action<ITween<T>> ProgressCallback { get; set; }

    /// <summary>
    /// End callback.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Action<ITween<T>> EndCallback { get; set; }

    /// <summary>
    /// Condition of progress, stops if the operation is not true.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Func<ITween<T>, bool> ConditionFunction { get; set; }

    private float currentTime;

    private int residueCount = -1;

    // Tween, start, end, progress.
    private readonly Func<ITween<T>, T, T, float, T> lerpFunction;

    private object owner = null;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="lerpFunc">T linear interpolation function.</param>
    public Tween(Func<ITween<T>, T, T, float, T> lerpFunction)
    {
      Check.IsNotNull(lerpFunction);

      this.lerpFunction = lerpFunction;
    }

    public Tween<T> SetOwner(object owner)
    {
      IsOwned = owner != null;
      this.owner = owner;

      return this;
    }

    /// <summary>
    /// Execute a tween operation.
    /// </summary>
    public void Start() => Start(ValueStart, ValueEnd, Duration, Easing);

    /// <summary>
    /// Comienza una operacion de tween.
    /// </summary>
    /// <param name="start">Valor inicial.</param>
    /// <param name="end">Valor final.</param>
    /// <param name="duration">Duracion en segundos de la operacion.</param>
    /// <param name="easing">Easing function.</param>
    public void Start(T start, T end, float duration, EasingFunction easing) => Start(start, end, duration, easing, ProgressCallback, Execution, EndCallback, ConditionFunction);

    /// <summary>
    /// Execute a tween operation.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing function.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Behavior when reaching the final value: once, loop, yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition callback. If the condition is not fulfilled, the tween ends.</param>
    public void Start(T start,
                      T end,
                      float duration,
                      EasingFunction easing,
                      Action<ITween<T>> progressCallback,
                      TweenExecution execution = TweenExecution.Once,
                      Action<ITween<T>> endCallback = null,
                      Func<ITween<T>, bool> conditionFunc = null)
    {
      Check.Greater(duration, 0.0f);

      ValueStart = start;
      ValueEnd = end;
      Duration = duration;
      Easing = easing;
      ProgressCallback = progressCallback;
      Execution = execution;
      EndCallback = endCallback;
      ConditionFunction = conditionFunc;
      currentTime = 0.0f;
      State = TweenState.Running;

      UpdateValue();
    }

    /// <summary>
    /// Pause the Tween operation.
    /// </summary>
    public void Pause() => State = TweenState.Paused;

    /// <summary>
    /// Continue the Tweeen operation.
    /// </summary>
    public void Resume() => State = TweenState.Running;

    /// <summary>
    /// Finish the Tween operation.
    /// </summary>
    /// <param name="moveToEnd">Move the value at the end or leave it as this.</param>
    public void Stop(bool moveToEnd = true)
    {
      if (State != TweenState.Finished)
      {
        State = TweenState.Finished;
        if (moveToEnd == true)
        {
          currentTime = Duration;

          UpdateValue();

          EndCallback?.Invoke(this);
        }
      }
    }

    /// <summary>
    /// Update the Tween operation.
    /// </summary>
    public void Update()
    {
      if ((IsOwned == true && owner.Equals(null)) || (ConditionFunction != null && ConditionFunction(this) == false))
        Stop(false);
      else
      {
        currentTime += UnityEngine.Time.deltaTime;
        if (currentTime >= Duration)
        {
          residueCount--;
          ExecutionCount++;

          switch (Execution)
          {
            case TweenExecution.Once:
              Stop(true);
              break;

            case TweenExecution.Loop:
              if (residueCount == 0)
                Stop(true);

              Value = ValueStart;
              currentTime = Progress = 0.0f;
              break;

            case TweenExecution.YoYo:
              if (residueCount == 0)
                Stop(true);

              (ValueEnd, ValueStart) = (ValueStart, ValueEnd);

              currentTime = Progress = 0.0f;
              break;
          }
        }
        else
          UpdateValue();
      }
    }

    private void UpdateValue()
    {
      Check.IsNotNull(lerpFunction);

      Progress = Easing(currentTime / Duration);

      Value = lerpFunction(this, ValueStart, ValueEnd, Progress);

      ProgressCallback?.Invoke(this);
    }
  }
}
