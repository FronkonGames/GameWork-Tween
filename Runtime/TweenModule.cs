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
    /// Add an existing tween.
    /// </summary>
    internal void Add(ITween tween)
    {
      Check.IsNotNull(tween);

      tweens.Add(tween);
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

        tween.Update();
        
        if (tween.State == TweenState.Finished && i < count)
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
