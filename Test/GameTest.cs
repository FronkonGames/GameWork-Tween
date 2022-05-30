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
using System.Collections.Generic;
using UnityEngine;
using FronkonGames.GameWork.Core;

namespace FronkonGames.GameWork.Modules.TweenModule
{
  /// <summary>
  /// .
  /// </summary>
  public sealed class GameTest : Game
  {
    [SerializeField]
    private TweenModule tweenModule;

    [SerializeField]
    private GameObject starPrefab;

    [SerializeField, Range(0.1f, 5.0f)]
    private float duration;

    private List<GameObject> starts = new List<GameObject>();

    /// <summary>
    /// On initialize.
    /// </summary>
    public override void OnInitialize()
    {
      RegisterModule(tweenModule);

      float y = 1.0f;

      // Position.
      for (int i = 0; i < (int)Easing.BounceInOut; ++i)
      {
        GameObject star = GameObject.Instantiate(starPrefab);
        star.name = $"Star {(Easing)i}";
        tweenModule.Create(new Vector3(33.0f, y, 0.0f), new Vector3(-33.0f, y, 0.0f), duration, (Easing)i, (tween) => star.transform.position = tween.Value, TweenExecution.YoYo);
        y += 1.0f;
      }
    }

    /// <summary>
    /// At the end of initialization.
    /// Called in the first Update frame.
    /// </summary>
    public override void OnInitialized()
    {
    }
  }
}
