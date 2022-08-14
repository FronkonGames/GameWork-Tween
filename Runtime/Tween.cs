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

    /// <summary>
    /// Current value.
    /// </summary>
    public T Value { get; private set; }

    /// <summary>
    /// Tween operation progress (0, 1).
    /// </summary>
    public float Progress { get; private set; }

    /// <summary>
    /// Executions counter.
    /// </summary>
    public int ExecutionCount { get; private set; }

    /// <summary>
    /// Time that the operation takes.
    /// </summary>
    public float Time { get; private set; }

    private bool IsOwned { get; set; }
    
    private object owner = null;
    
    private T start, end;

    private EasingFunction easing = Linear.InOut;

    private TweenLoop loop = TweenLoop.Once;

    private float duration = 1.0f;
    private float currentTime;

    private Action<ITween<T>> updateCallback;
    private Action<ITween<T>> endCallback;
    private Func<ITween<T>, bool> condition;

    private int residueCount = -1;

    // Tween, start, end, progress.
    private readonly Func<ITween<T>, T, T, float, T> lerpFunction;

    /// <summary>
    /// Initial value.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> Start(T start)
    {
      this.start = start;

      return this;
    }

    /// <summary>
    /// Final value.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> End(T end)
    {
      this.end = end;

      return this;
    }

    /// <summary>
    /// Time to execute the operation.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> Duration(float duration)
    {
      Check.Greater(duration, 0.0f);
      this.duration = duration;

      return this;
    }

    /// <summary>
    /// Execution mode.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> Loop(TweenLoop loop)
    {
      this.loop = loop;

      return this;
    }
    
    /// <summary>
    /// Easing function.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    /// <param name="easing">Easing function.</param>
    /// <returns>This.</returns>
    public Tween<T> Easing(EasingFunction easing)
    {
      this.easing = easing;

      return this;
    }
    
    /// <summary>
    /// Update callback.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> OnUpdate(Action<ITween<T>> updateCallback)
    {
      this.updateCallback = updateCallback;

      return this;
    }

    /// <summary>
    /// End callback.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> OnEnd(Action<ITween<T>> endCallback)
    {
      this.endCallback = endCallback;

      return this;
    }

    /// <summary>
    /// Condition of progress, stops if the operation is not true.
    /// Use only when the operation is over (State == TweenState.Finished).
    /// </summary>
    public Tween<T> ConditionFunction(Func<ITween<T>, bool> condition)
    {
      this.condition = condition;

      return this;
    }
    
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="lerpFunc">T linear interpolation function.</param>
    protected Tween(Func<ITween<T>, T, T, float, T> lerpFunction)
    {
      Check.IsNotNull(lerpFunction);

      this.lerpFunction = lerpFunction;
    }

    public Tween<T> Owner(object owner)
    {
      IsOwned = owner != null;
      this.owner = owner;

      return this;
    }

    /// <summary>
    /// Execute a tween operation.
    /// </summary>
    public Tween<T> Start()
    {
      State = TweenState.Running;
      
      UpdateValue();

      return this;
    }

    /// <summary>
    /// Execute a tween operation.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing function.</param>
    /// <param name="updateCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="loop">Behavior when reaching the final value: once, loop, yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="condition">Condition callback. If the condition is not fulfilled, the tween ends.</param>
    public void Start(T start,
                      T end,
                      float duration,
                      EasingFunction easing,
                      Action<ITween<T>> updateCallback,
                      TweenLoop loop = TweenLoop.Once,
                      Action<ITween<T>> endCallback = null,
                      Func<ITween<T>, bool> condition = null)
    {
      Check.Greater(duration, 0.0f);

      this.start = start;
      this.end = end;
      this.duration = duration;
      this.easing = easing;
      this.updateCallback = updateCallback;
      this.loop = loop;
      this.endCallback = endCallback;
      this.condition = condition;
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
          currentTime = duration;

          UpdateValue();

          endCallback?.Invoke(this);
        }
      }
    }

    /// <summary>
    /// Update the Tween operation.
    /// </summary>
    public void Update()
    {
      if ((IsOwned == true && owner.Equals(null)) || (condition != null && condition(this) == false))
        Stop(false);
      else
      {
        currentTime += UnityEngine.Time.deltaTime;
        if (currentTime >= duration)
        {
          residueCount--;
          ExecutionCount++;

          switch (loop)
          {
            case TweenLoop.Once:
              Stop(true);
              break;

            case TweenLoop.Loop:
              if (residueCount == 0)
                Stop(true);

              Value = start;
              currentTime = Progress = 0.0f;
              break;

            case TweenLoop.YoYo:
              if (residueCount == 0)
                Stop(true);

              (end, start) = (start, end);

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

      Progress = easing(currentTime / duration);

      Value = lerpFunction(this, start, end, Progress);

      updateCallback?.Invoke(this);
    }
  }
}
