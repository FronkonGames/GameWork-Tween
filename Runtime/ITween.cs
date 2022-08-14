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

namespace FronkonGames.GameWork.Modules.Tween
{
  /// <summary>
  /// Interface of a tween.
  /// </summary>
  public interface ITween
  {
    /// <summary>
    /// Current status of Tween operation.
    /// </summary>
    TweenState State { get; }
    
    bool IsOwned { get; }

    /// <summary>
    /// Pause the tween operation.
    /// </summary>
    void Pause();

    /// <summary>
    /// Continue the tweeen operation.
    /// </summary>
    void Resume();

    /// <summary>
    /// Finish the Tween operation.
    /// </summary>
    /// <param name="moveToEnd">Move the value at the end or leave it as this.</param>
    void Stop(bool moveToEnd);

    /// <summary>
    /// Update the Tween operation.
    /// </summary>
    void Update();
  }

  /// <summary>
  /// Generic interface of a tween.
  /// </summary>
  public interface ITween<T> : ITween where T : struct
  {
    /// <summary>
    /// Current value.
    /// </summary>
    T Value { get; }

    /// <summary>
    /// Tween operation progress (0, 1).
    /// </summary>
    float Progress { get; }

    /// <summary>
    /// Executions counter.
    /// </summary>
    int ExecutionCount { get; }

    /// <summary>
    /// Set tween owner. If the owner is destroyed, the tween is removed.
    /// </summary>
    /// <param name="owner">Owner</param>
    /// <returns>Tween.</returns>
    public Tween<T> SetOwner(object owner);
    
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
    void Start(T start,
               T end,
               float duration,
               EasingFunction easing,
               Action<ITween<T>> progressCallback,
               TweenExecution execution = TweenExecution.Once,
               Action<ITween<T>> endCallback = null,
               Func<ITween<T>, bool> conditionFunc = null);
  }
}
