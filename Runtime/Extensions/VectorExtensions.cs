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
  /// 
  /// </summary>
  public static class VectorExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Tween<Vector2> Tween(this Vector2 self, Vector2 end = default) =>
      TweenVector2.Create(self)
        .End(end)
        .OnUpdate((tween) => self = tween.Value)
        .Owner(self);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Tween<Vector3> Tween(this Vector3 self, Vector3 end = default) =>
      TweenVector3.Create(self)
        .End(end)
        .OnUpdate((tween) => self = tween.Value)
        .Owner(self);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static Tween<Vector4> Tween(this Vector4 self, Vector4 end = default) =>
      TweenVector4.Create(self)
        .End(end)
        .OnUpdate((tween) => self = tween.Value)
        .Owner(self);
  }
}
