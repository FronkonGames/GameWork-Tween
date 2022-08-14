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
using UnityEngine;
// @TODO: Add UnityEngine.Pool; 
using FronkonGames.GameWork.Foundation;
using FronkonGames.GameWork.Core;

namespace FronkonGames.GameWork.Modules.Tween
{
  /// <summary>
  /// Tween module.
  /// </summary>
  public sealed class TweenModule : MonoBehaviourModule,
                                    IInitializable,
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
    
    /// <summary>
    /// 
    /// </summary>
    internal static TweenModule Instance { get; private set; }

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
                             EasingFunction easing,
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
    /// Creates a Tween Color.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenColor Create(Color start,
                             Color end,
                             float duration,
                             EasingFunction easing,
                             Action<ITween<Color>> progressCallback,
                             TweenExecution execution = TweenExecution.Once,
                             Action<ITween<Color>> endCallback = null,
                             Func<ITween<Color>, bool> conditionFunc = null)
    {
      TweenColor tween = new TweenColor();
      tween.Start(start, end, duration, easing, progressCallback, execution, endCallback, conditionFunc);

      Add(tween);

      return tween;
    }

    /// <summary>
    /// Creates a Tween Vector2.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenVector2 Create(Vector2 start,
                               Vector2 end,
                               float duration,
                               EasingFunction easing,
                               Action<ITween<Vector2>> progressCallback,
                               TweenExecution execution = TweenExecution.Once,
                               Action<ITween<Vector2>> endCallback = null,
                               Func<ITween<Vector2>, bool> conditionFunc = null)
    {
      TweenVector2 tween = new TweenVector2();
      tween.Start(start, end, duration, easing, progressCallback, execution, endCallback, conditionFunc);

      Add(tween);

      return tween;
    }

    /// <summary>
    /// Creates a Tween Vector3.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenVector3 Create(Vector3 start,
                               Vector3 end,
                               float duration,
                               EasingFunction easing,
                               Action<ITween<Vector3>> progressCallback,
                               TweenExecution execution = TweenExecution.Once,
                               Action<ITween<Vector3>> endCallback = null,
                               Func<ITween<Vector3>, bool> conditionFunc = null)
    {
      TweenVector3 tween = new TweenVector3();
      tween.Start(start, end, duration, easing, progressCallback, execution, endCallback, conditionFunc);

      Add(tween);

      return tween;
    }

    /// <summary>
    /// Creates a Tween Vector4.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenVector4 Create(Vector4 start,
                               Vector4 end,
                               float duration,
                               EasingFunction easing,
                               Action<ITween<Vector4>> progressCallback,
                               TweenExecution execution = TweenExecution.Once,
                               Action<ITween<Vector4>> endCallback = null,
                               Func<ITween<Vector4>, bool> conditionFunc = null)
    {
      TweenVector4 tween = new TweenVector4();
      tween.Start(start, end, duration, easing, progressCallback, execution, endCallback, conditionFunc);

      Add(tween);

      return tween;
    }

    /// <summary>
    /// Creates a Tween Quaternion.
    /// </summary>
    /// <param name="start">Initial value.</param>
    /// <param name="end">Final value.</param>
    /// <param name="duration">Duration in seconds of the operation.</param>
    /// <param name="easing">Easing type.</param>
    /// <param name="progressCallback">Progress callback. Necessary to update the value.</param>
    /// <param name="execution">Execution mode: Once, Loop, Yoyo.</param>
    /// <param name="endCallback">End callback.</param>
    /// <param name="conditionFunc">Condition function. If the condition is not true, the tween ends.</param>
    public TweenQuaternion Create(Quaternion start,
                                  Quaternion end,
                                  float duration,
                                  EasingFunction easing,
                                  Action<ITween<Quaternion>> progressCallback,
                                  TweenExecution execution = TweenExecution.Once,
                                  Action<ITween<Quaternion>> endCallback = null,
                                  Func<ITween<Quaternion>, bool> conditionFunc = null)
    {
      TweenQuaternion tween = new TweenQuaternion();
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
      Check.IsNull(Instance);

      Instance = this;
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
      Instance = null;

      tweens.Clear();
    }

    /// <summary>
    /// Update event.
    /// </summary>
    public void OnUpdate()
    {
      int count = tweens.Count;
      for (int i = count - 1; i >= 0; --i)
      {
        ITween tween = tweens[i];
        if (tween.Update() == true && i < count)
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
