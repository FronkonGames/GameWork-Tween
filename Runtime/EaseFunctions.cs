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
using UnityEngine;
using FronkonGames.GameWork.Foundation;

namespace FronkonGames.GameWork.Modules.TweenModule
{
  /// <summary>
  /// .
  /// </summary>
  public static class EaseFunctions
  {
    private const float ConstantA = 1.70158f;
    private const float ConstantB = ConstantA * 1.525f;
    private const float ConstantC = ConstantA + 1.0f;
    private const float ConstantD = (2.0f * MathConstants.Pi) / 3.0f;
    private const float ConstantE = (2.0f * MathConstants.Pi) / 4.5f;
    private const float ConstantF = 7.5625f;
    private const float ConstantG = 2.75f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ease"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    public static float Evaluate(EaseType ease, float time)
    {
      switch (ease)
      {
        case EaseType.Linear:       return time;

        case EaseType.SineIn:       return 1.0f - Mathf.Cos((time * MathConstants.Pi) * 0.5f);
        case EaseType.SineOut:      return Mathf.Sin((time * MathConstants.Pi) * 0.5f);
        case EaseType.SineInOut:    return -(Mathf.Cos(MathConstants.Pi * time) - 1.0f) * 0.5f;

        case EaseType.QuadIn:       return time * time;
        case EaseType.QuadOut:      return 1.0f - (1.0f - time) * (1.0f - time);
        case EaseType.QuadInOut:    return time < 0.5f ? 2.0f * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 2) * 0.5f;

        case EaseType.CubicIn:      return time * time * time;
        case EaseType.CubicOut:     return 1.0f - Mathf.Pow(1.0f - time, 3);
        case EaseType.CubicInOut:   return time < 0.5f ? 4.0f * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 3) * 0.5f;

        case EaseType.QuartIn:      return time * time * time * time;
        case EaseType.QuartOut:     return 1.0f - Mathf.Pow(1.0f - time, 4);
        case EaseType.QuartInOut:   return time < 0.5 ? 8.0f * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 4) * 0.5f;

        case EaseType.QuintIn:      return time * time * time * time * time;
        case EaseType.QuintOut:     return 1.0f - Mathf.Pow(1.0f - time, 5);
        case EaseType.QuintInOut:   return time < 0.5f ? 16.0f * time * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 5) * 0.5f;

        case EaseType.ExpoIn:       return time.NearlyEquals(0.0f) ? 0.0f : Mathf.Pow(2.0f, 10 * time - 10);
        case EaseType.ExpoOut:      return time.NearlyEquals(1.0f) ? 1.0f : 1.0f - Mathf.Pow(2.0f, -10 * time);
        case EaseType.ExpoInOut:    return time.NearlyEquals(0.0f) ? 0.0f :
                                                                     time.NearlyEquals(1.0f) ? 1.0f :
                                                                                               time < 0.5 ? Mathf.Pow(2.0f, 20 * time - 10) * 0.5f :
                                                                                                            (2.0f - Mathf.Pow(2.0f, -20 * time + 10)) * 0.5f;

        case EaseType.CircIn:       return 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(time, 2));
        case EaseType.CircOut:      return Mathf.Sqrt(1.0f - Mathf.Pow(time - 1.0f, 2));
        case EaseType.CircInOut:    return time < 0.5f ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * time, 2))) * 0.5f :
                                                         (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * time + 2.0f, 2)) + 1.0f) * 0.5f;

        case EaseType.BackIn:       return ConstantC * time * time * time - ConstantA * time * time;
        case EaseType.BackOut:      return 1.0f + ConstantC * Mathf.Pow(time - 1.0f, 3) + ConstantA * Mathf.Pow(time - 1.0f, 2);
        case EaseType.BackInOut:    return time < 0.5f ? 16.0f * time * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 5) * 0.5f;

        case EaseType.ElasticIn:    return time.NearlyEquals(0.0f) ? 0.0f :
                                            time.NearlyEquals(1.0f) ? 1.0f :
                                              -Mathf.Pow(2.0f, 10 * time - 10) * Mathf.Sin((time * 10.0f - 10.75f) * ConstantD);
        case EaseType.ElasticOut:   return time.NearlyEquals(0.0f) ? 0.0f :
                                            time.NearlyEquals(1.0f) ? 1.0f :
                                              Mathf.Pow(2.0f, -10 * time) * Mathf.Sin((time * 10.0f - 0.75f) * ConstantD) + 1.0f;
        case EaseType.ElasticInOut: return time.NearlyEquals(0.0f) ? 0.0f :
                                            time.NearlyEquals(1.0f) ? 1.0f :
                                              time < 0.5f ? -(Mathf.Pow(2.0f, 20 * time - 10) * Mathf.Sin((20.0f * time - 11.125f) * ConstantE)) * 0.5f :
                                                (Mathf.Pow(2.0f, -20 * time + 10) * Mathf.Sin((20.0f * time - 11.125f) * ConstantE)) * 0.5f + 1.0f;

        case EaseType.BounceIn:     return 1.0f - EaseFunctions.Evaluate(EaseType.BounceOut, 1.0f - time);
        case EaseType.BounceOut:
        {
          if (time < 1.0f / ConstantG)
            return ConstantF * time * time;
          else if (time < 2.0f / ConstantG)
            return ConstantF * (time -= 1.5f / ConstantG) * time + 0.75f;
          else if (time < 2.5f / ConstantG)
            return ConstantF * (time -= 2.25f / ConstantG) * time + 0.9375f;

          return ConstantF * (time -= 2.625f / ConstantG) * time + 0.984375f;
        }
        case EaseType.BounceInOut:  return time < 0.5f ? (1.0f - EaseFunctions.Evaluate(EaseType.BounceOut, 1.0f - 2.0f * time)) * 0.5f :
                                            (1.0f + EaseFunctions.Evaluate(EaseType.BounceOut, 2.0f * time - 1.0f)) * 0.5f;

        default: return 0.0f;
      }
    }
  }
}
