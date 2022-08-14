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

namespace FronkonGames.GameWork.Modules.Tween
{
  /// <summary>
  /// 
  /// </summary>
  public static class TransformExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="to"></param>
    /// <param name="duration"></param>
    /// <param name="easing"></param>
    /// <param name="execution"></param>
    /// <param name="endCallback"></param>
    /// <param name="conditionFunc"></param>
    /// <returns></returns>
    public static TweenVector2 TweenPosition(this Transform transform,
                                             Vector2 to,
                                             float duration,
                                             EasingFunction easing,
                                             TweenExecution execution = TweenExecution.Once,
                                             Action<ITween<Vector2>> endCallback = null,
                                             Func<ITween<Vector2>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.position,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.position = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }
    
    public static TweenVector3 TweenPosition(this Transform transform,
                                             Vector3 to,
                                             float duration,
                                             EasingFunction easing,
                                             TweenExecution execution = TweenExecution.Once,
                                             Action<ITween<Vector3>> endCallback = null,
                                             Func<ITween<Vector3>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.position,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.position = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }
    
    public static TweenVector4 TweenPosition(this Transform transform,
                                             Vector4 to,
                                             float duration,
                                             EasingFunction easing,
                                             TweenExecution execution = TweenExecution.Once,
                                             Action<ITween<Vector4>> endCallback = null,
                                             Func<ITween<Vector4>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.position,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.position = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }
    
    public static TweenQuaternion TweenRotation(this Transform transform,
                                                Quaternion to,
                                                float duration,
                                                EasingFunction easing,
                                                TweenExecution execution = TweenExecution.Once,
                                                Action<ITween<Quaternion>> endCallback = null,
                                                Func<ITween<Quaternion>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.localRotation,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.localRotation = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }

    public static TweenVector3 TweenScale(this Transform transform,
                                          Vector3 to,
                                          float duration,
                                          EasingFunction easing,
                                          TweenExecution execution = TweenExecution.Once,
                                          Action<ITween<Vector3>> endCallback = null,
                                          Func<ITween<Vector3>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.localScale,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.localScale = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }
    
    public static TweenColor TweenColor(this Transform transform,
                                        Color to,
                                        float duration,
                                        EasingFunction easing,
                                        TweenExecution execution = TweenExecution.Once,
                                        Action<ITween<Color>> endCallback = null,
                                        Func<ITween<Color>, bool> conditionFunc = null)
    {
      return TweenModule.Instance.Create(transform.GetComponent<Renderer>().material.color,
                                         to,
                                         duration,
                                         easing,
                                         (tween) => transform.GetComponent<Renderer>().material.color = tween.Value,
                                         execution,
                                         endCallback,
                                         conditionFunc);
    }    
  }
}
