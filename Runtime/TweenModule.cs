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
// using UnityEngine;
// using UnityEngine.Pool; TODO
using FronkonGames.GameWork.Foundation;
using FronkonGames.GameWork.Core;

namespace FronkonGames.GameWork.Modules.TweenModule
{
  /// <summary>
  /// .
  /// </summary>
  public sealed class TweenModule : IInitializable,
                                    IUpdatable
  {
    /// <summary>
    /// Is it initialized?
    /// </summary>
    /// <value>Value</value>
    public bool Initialized { get; set; }

    /// <summary>
    /// Should be updated?
    /// </summary>
    /// <value>True/false.</value>
    public bool ShouldUpdate { get; } = true;

    private readonly FastList<ITween> tweens = new FastList<ITween>();

    /// <summary>
    /// Creates a Tween Float.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenFloat Create(float start,
                             float end,
                             float duration,
                             Easing easing,
                             Action<ITween<float>> progressCallback,
                             TweenExecution execution = TweenExecution.Once,
                             Action<ITween<float>> endCallback = null,
                             Func<ITween<float>, bool> conditionFunc = null)
    {
      TweenFloat tween = new TweenFloat();
      tween.Start(start, end, duration, easing, progressCallback, execution, endCallback, conditionFunc);

      Add(tween);

      return tween;
    }

    /// <summary>
    /// Add an existing tween.
    /// </summary>
    public void Add(ITween tween)
    {
      Check.IsNotNull(tween);

      tweens.Add(tween);
    }

    /// <summary>
    /// Remove a tween.
    /// </summary>
    public bool Remove(ITween tween, bool moveToEnd = false)
    {
      Check.IsNotNull(tween);

      tween.Stop(moveToEnd);

      return tweens.Remove(tween);
    }

    /// <summary>
    /// When initialize.
    /// </summary>
    public void OnInitialize()
    {
    }

    /// <summary>
    /// At the end of initialization.
    /// Called in the first Update frame.
    /// </summary>
    public void OnInitialized()
    {
    }

    /// <summary>
    /// When deinitialize.
    /// </summary>
    public void OnDeinitialize()
    {
      tweens.Clear();
    }

    /// <summary>
    /// Update event.
    /// </summary>
    public void OnUpdate()
    {
      for (int i = tweens.Count - 1; i >= 0; --i)
      {
        ITween tween = tweens[i];
        if (tween.Update() == true && i < tweens.Count)
          tweens.RemoveAt(i);
      }
    }

    /// <summary>
    /// FixedUpdate event.
    /// </summary>
    public void OnFixedUpdate()
    {
    }

    /// <summary>
    /// LateUpdate event.
    /// </summary>
    public void OnLateUpdate()
    {
    }
  }
}
