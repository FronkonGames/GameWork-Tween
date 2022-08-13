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

namespace FronkonGames.GameWork.Modules.Tween
{
  /// <summary>
  /// Tween float.
  /// </summary>
  public class TweenFloat : Tween<float>
  {
    private static float Lerp(ITween<float> t, float start, float end, float progress) => Mathf.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenFloat() : base(Lerp) { }
  }

  /// <summary>
  /// Tween color.
  /// </summary>
  public class TweenColor : Tween<Color>
  {
    private static Color Lerp(ITween<Color> t, Color start, Color end, float progress) => Color.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenColor() : base(Lerp) { }
  }

  /// <summary>
  /// Tween Vector2.
  /// </summary>
  public class TweenVector2 : Tween<Vector2>
  {
    private static Vector2 Lerp(ITween<Vector2> t, Vector2 start, Vector2 end, float progress) => Vector2.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenVector2() : base(Lerp) { }
  }

  /// <summary>
  /// Tween Vector3.
  /// </summary>
  public class TweenVector3 : Tween<Vector3>
  {
    private static Vector3 Lerp(ITween<Vector3> t, Vector3 start, Vector3 end, float progress) => Vector3.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenVector3() : base(Lerp) { }
  }

  /// <summary>
  /// Tween Vector4.
  /// </summary>
  public class TweenVector4 : Tween<Vector4>
  {
    private static Vector4 Lerp(ITween<Vector4> t, Vector4 start, Vector4 end, float progress) => Vector4.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenVector4() : base(Lerp) { }
  }

  /// <summary>
  /// Tween Quaternion.
  /// </summary>
  public class TweenQuaternion : Tween<Quaternion>
  {
    private static Quaternion Lerp(ITween<Quaternion> t, Quaternion start, Quaternion end, float progress) => Quaternion.LerpUnclamped(start, end, progress);

    /// <summary>Constructor.</summary>
    public TweenQuaternion() : base(Lerp) { }
  }
}
