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
    /// <param name="value"></param>
    /// <returns></returns>
    public static float Evaluate(Easing ease, float value)
    {
      switch (ease)
      {
        case Easing.Linear:       return value;

        case Easing.SineIn:       return 1.0f - Mathf.Cos((value * MathConstants.Pi) * 0.5f);
        case Easing.SineOut:      return Mathf.Sin((value * MathConstants.Pi) * 0.5f);
        case Easing.SineInOut:    return -(Mathf.Cos(MathConstants.Pi * value) - 1.0f) * 0.5f;

        case Easing.QuadIn:       return value * value;
        case Easing.QuadOut:      return 1.0f - (1.0f - value) * (1.0f - value);
        case Easing.QuadInOut:    return value < 0.5f ? 2.0f * value * value : 1.0f - Mathf.Pow(-2.0f * value + 2.0f, 2) * 0.5f;

        case Easing.CubicIn:      return value * value * value;
        case Easing.CubicOut:     return 1.0f - Mathf.Pow(1.0f - value, 3);
        case Easing.CubicInOut:   return value < 0.5f ? 4.0f * value * value * value : 1.0f - Mathf.Pow(-2.0f * value + 2.0f, 3) * 0.5f;

        case Easing.QuartIn:      return value * value * value * value;
        case Easing.QuartOut:     return 1.0f - Mathf.Pow(1.0f - value, 4);
        case Easing.QuartInOut:   return value < 0.5 ? 8.0f * value * value * value * value : 1.0f - Mathf.Pow(-2.0f * value + 2.0f, 4) * 0.5f;

        case Easing.QuintIn:      return value * value * value * value * value;
        case Easing.QuintOut:     return 1.0f - Mathf.Pow(1.0f - value, 5);
        case Easing.QuintInOut:   return value < 0.5f ? 16.0f * value * value * value * value * value : 1.0f - Mathf.Pow(-2.0f * value + 2.0f, 5) * 0.5f;

        case Easing.ExpoIn:       return value.NearlyEquals(0.0f) ? 0.0f : Mathf.Pow(2.0f, 10 * value - 10);
        case Easing.ExpoOut:      return value.NearlyEquals(1.0f) ? 1.0f : 1.0f - Mathf.Pow(2.0f, -10 * value);
        case Easing.ExpoInOut:    return value.NearlyEquals(0.0f) ? 0.0f :
                                            value.NearlyEquals(1.0f) ? 1.0f :
                                              value < 0.5 ? Mathf.Pow(2.0f, 20 * value - 10) * 0.5f :
                                                (2.0f - Mathf.Pow(2.0f, -20 * value + 10)) * 0.5f;

        case Easing.CircIn:       return 1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(value, 2));
        case Easing.CircOut:      return Mathf.Sqrt(1.0f - Mathf.Pow(value - 1.0f, 2));
        case Easing.CircInOut:    return value < 0.5f ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * value, 2))) * 0.5f :
                                            (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * value + 2.0f, 2)) + 1.0f) * 0.5f;

        case Easing.BackIn:       return ConstantC * value * value * value - ConstantA * value * value;
        case Easing.BackOut:      return 1.0f + ConstantC * Mathf.Pow(value - 1.0f, 3) + ConstantA * Mathf.Pow(value - 1.0f, 2);
        case Easing.BackInOut:    return value < 0.5f ? 16.0f * value * value * value * value * value : 1.0f - Mathf.Pow(-2.0f * value + 2.0f, 5) * 0.5f;

        case Easing.ElasticIn:    return value.NearlyEquals(0.0f) ? 0.0f :
                                            value.NearlyEquals(1.0f) ? 1.0f :
                                              -Mathf.Pow(2.0f, 10 * value - 10) * Mathf.Sin((value * 10.0f - 10.75f) * ConstantD);
        case Easing.ElasticOut:   return value.NearlyEquals(0.0f) ? 0.0f :
                                            value.NearlyEquals(1.0f) ? 1.0f :
                                              Mathf.Pow(2.0f, -10 * value) * Mathf.Sin((value * 10.0f - 0.75f) * ConstantD) + 1.0f;
        case Easing.ElasticInOut: return value.NearlyEquals(0.0f) ? 0.0f :
                                            value.NearlyEquals(1.0f) ? 1.0f :
                                              value < 0.5f ? -(Mathf.Pow(2.0f, 20 * value - 10) * Mathf.Sin((20.0f * value - 11.125f) * ConstantE)) * 0.5f :
                                                (Mathf.Pow(2.0f, -20 * value + 10) * Mathf.Sin((20.0f * value - 11.125f) * ConstantE)) * 0.5f + 1.0f;

        case Easing.BounceIn:     return 1.0f - EaseFunctions.Evaluate(Easing.BounceOut, 1.0f - value);
        case Easing.BounceOut:
        {
          if (value < 1.0f / ConstantG)
            return ConstantF * value * value;
          else if (value < 2.0f / ConstantG)
            return ConstantF * (value -= 1.5f / ConstantG) * value + 0.75f;
          else if (value < 2.5f / ConstantG)
            return ConstantF * (value -= 2.25f / ConstantG) * value + 0.9375f;

          return ConstantF * (value -= 2.625f / ConstantG) * value + 0.984375f;
        }
        case Easing.BounceInOut:  return value < 0.5f ? (1.0f - EaseFunctions.Evaluate(Easing.BounceOut, 1.0f - 2.0f * value)) * 0.5f :
                                            (1.0f + EaseFunctions.Evaluate(Easing.BounceOut, 2.0f * value - 1.0f)) * 0.5f;

        default: return 0.0f;
      }
    }
  }
}
