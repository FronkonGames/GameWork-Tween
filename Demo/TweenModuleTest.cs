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
using FronkonGames.GameWork.Core;
using FronkonGames.GameWork.Modules.Tween;

/// <summary>
/// Tween module test.
/// </summary>
public sealed class TweenModuleTest : Game
{
  [SerializeField]
  private GameObject starPrefab;

  [SerializeField, Range(0.1f, 5.0f)]
  private float duration;

  [Inject]
  private TweenModule tweenModule;

  private Vector3 positionStart;
  private Vector3 positionEnd;

  /// <summary>
  /// On initialize.
  /// </summary>
  public override void OnInitialize()
  {
  }

  /// <summary>
  /// At the end of initialization.
  /// Called in the first Update frame.
  /// </summary>
  public override void OnInitialized()
  {
    positionStart = new(15.0f, 1.0f, 0.0f);
    positionEnd = new(-15.0f, 1.0f, 0.0f);

    // Position.
    InstantiatePosition(Linear.InOut);
    InstantiatePosition(Cubic.InOut);
    InstantiatePosition(Quartic.InOut);
    InstantiatePosition(Quintic.InOut);
    InstantiatePosition(Sinusoidal.InOut);
    InstantiatePosition(Exponential.InOut);
    InstantiatePosition(Circular.InOut);
    InstantiatePosition(Elastic.InOut);
    InstantiatePosition(Back.InOut);
    InstantiatePosition(Bounce.InOut);

    positionStart.AddY(-1.0f);
    
    // Rotation.
    InstantiateRotation(Linear.InOut);
    InstantiateRotation(Cubic.InOut);
    InstantiateRotation(Quartic.InOut);
    InstantiateRotation(Quintic.InOut);
    InstantiateRotation(Sinusoidal.InOut);
    InstantiateRotation(Exponential.InOut);
    InstantiateRotation(Circular.InOut);
    InstantiateRotation(Elastic.InOut);
    InstantiateRotation(Back.InOut);
    InstantiateRotation(Bounce.InOut);
    
    positionStart = new(15.0f, positionStart.y - 1.0f, 0.0f);

    // Scale.
    InstantiateScale(Linear.InOut);
    InstantiateScale(Cubic.InOut);
    InstantiateScale(Quartic.InOut);
    InstantiateScale(Quintic.InOut);
    InstantiateScale(Sinusoidal.InOut);
    InstantiateScale(Exponential.InOut);
    InstantiateScale(Circular.InOut);
    InstantiateScale(Elastic.InOut);
    InstantiateScale(Back.InOut);
    InstantiateScale(Bounce.InOut);
    
    positionStart = new(15.0f, positionStart.y - 1.0f, 0.0f);
    
    // Color.
    InstantiateColor(Linear.InOut);
    InstantiateColor(Cubic.InOut);
    InstantiateColor(Quartic.InOut);
    InstantiateColor(Quintic.InOut);
    InstantiateColor(Sinusoidal.InOut);
    InstantiateColor(Exponential.InOut);
    InstantiateColor(Circular.InOut);
    InstantiateColor(Elastic.InOut);
    InstantiateColor(Back.InOut);
    InstantiateColor(Bounce.InOut);
  }

  private void InstantiatePosition(EasingFunction easing)
  {
    GameObject gameObject = Instantiate(starPrefab, positionStart, Quaternion.identity);

    gameObject.transform.TweenPosition(positionEnd)
      .Duration(duration)
      .Easing(easing)
      .Loop(TweenLoop.YoYo)
      .Start();
    
    positionStart = positionStart.AddY(-1.0f);
    positionEnd = positionEnd.AddY(-1.0f);
  }

  private void InstantiateRotation(EasingFunction easing)
  {
    GameObject gameObject = Instantiate(starPrefab, positionStart, Quaternion.identity);

    gameObject.transform.TweenRotation(Quaternion.Euler(0.0f,  Random.Range(180.0f, 360.0f), 0.0f))
      .Duration(duration)
      .Easing(easing)
      .Loop(TweenLoop.YoYo)
      .Start();
    
    positionStart = positionStart.AddX(-3.0f);
  }
  
  private void InstantiateScale(EasingFunction easing)
  {
    GameObject gameObject = Instantiate(starPrefab, positionStart, Quaternion.identity);

    gameObject.transform.TweenScale(Vector3.zero)
      .Duration(duration)
      .Easing(easing)
      .Loop(TweenLoop.YoYo)
      .Start();

    positionStart = positionStart.AddX(-3.0f);
  }
  
  private void InstantiateColor(EasingFunction easing)
  {
    GameObject gameObject = Instantiate(starPrefab, positionStart, Quaternion.identity);

    gameObject.transform.TweenColor( FronkonGames.GameWork.Foundation.ColorExtensions.Random())
      .Duration(duration)
      .Easing(easing)
      .Loop(TweenLoop.YoYo)
      .Start();

    positionStart = positionStart.AddX(-3.0f);
  }
}
