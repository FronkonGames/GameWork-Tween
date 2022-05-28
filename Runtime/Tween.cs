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

namespace FronkonGames.GameWork.Modules.TweenModule
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
    /// Execute a tween operation.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="tweenFunc">Function that modifies progress. It must return values between 0 and 1.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Behavior when reaching the final value: once, loop, yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition callback. If the condition is not fulfilled, the tween ends.</param>
    public void Start(T start, T end, float duration, Func<float, float> tweenFunc, Action<ITween<T>> progressCallback,
                      TweenExecution execution = TweenExecution.Once,
                      Action<ITween<T>> endCallback = null,
                      Func<ITween<T>, bool> conditionFunc = null)
    {
    }

    /// <summary>
    /// Pause the Tween operation.
    /// </summary>
    public void Pause()
    {
    }

    /// <summary>
    /// Continue the Tweeen operation.
    /// </summary>
    public void Resume()
    {
    }

    /// <summary>
    /// Finish the Tween operation.
    /// </summary>
    /// <param name="moveToEnd">Move the value at the end or leave it as this.</param>
    public void Stop(bool moveToEnd = true)
    {
    }

    /// <summary>
    /// Update the Tween operation.
    /// </summary>
    /// <returns>True if it finish.</returns>
    public bool Update()
    {
      return false;
    }

    private void ExecutionYoyo()
    {
    }

    private void ExecutionLoop()
    {
    }

    private void UpdateValue()
    {
    }
  }
}
