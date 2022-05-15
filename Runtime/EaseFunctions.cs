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

    public static float Evaluate(EaseType ease, float value)
    {
      switch (ease)
      {
        case EaseType.Linear:     return value;
        case EaseType.SineIn:     return 1.0f - Mathf.Cos((value * MathConstants.Pi) / 2.0f);
        case EaseType.SineOut:    return Mathf.Sin((value * MathConstants.Pi) / 2.0f);
        case EaseType.SineInOut:  return -(Mathf.Cos(MathConstants.Pi * value) - 1.0f) / 2.0f;

        default: return 0.0f;
      }
    }
  }
}
