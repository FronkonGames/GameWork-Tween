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

namespace FronkonGames.GameWork.Modules.TweenModule
{
  /// <summary>
  /// .
  /// </summary>
  public enum EaseType
  {
    /// <summary>
    /// The tween will ease using a linear motion.
    /// </summary>
    Linear,

    /// <summary>
    /// The tween will ease using a sine in/out motion.
    /// </summary>
    SineIn,
    SineOut,
    SineInOut,

    /// <summary>
    /// The tween will ease using a quad in/out motion.
    /// </summary>
    QuadIn,
    QuadOut,
    QuadInOut,

    /// <summary>
    /// The tween will ease using a cubic in/out motion.
    /// </summary>
    CubicIn,
    CubicOut,
    CubicInOut,

    /// <summary>
    /// The tween will ease using a quart in/out motion.
    /// </summary>
    QuartIn,
    QuartOut,
    QuartInOut,

    /// <summary>
    /// The tween will ease using a quint in/out motion.
    /// </summary>
    QuintIn,
    QuintOut,
    QuintInOut,

    /// <summary>
    /// The tween will ease using a expo in/out motion.
    /// </summary>
    ExpoIn,
    ExpoOut,
    ExpoInOut,

    /// <summary>
    /// The tween will ease using a circ in/out motion.
    /// </summary>
    CircIn,
    CircOut,
    CircInOut,

    /// <summary>
    /// The tween will ease using a back in/out motion.
    /// </summary>
    BackIn,
    BackOut,
    BackInOut,

    /// <summary>
    /// The tween will ease using a elastic in/out motion.
    /// </summary>
    ElasticIn,
    ElasticOut,
    ElasticInOut,

    /// <summary>
    /// The tween will ease using a bounce in/out motion.
    /// </summary>
    BounceIn,
    BounceOut,
    BounceInOut,
  }
}
