using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ResultDirector : DirectorBase, IResultDirector
{
    async UniTask Start()
    {
        await DOTween.Sequence()
            .SetDelay(1.0f)
            .OnComplete(
                () =>
                {
                    executeSceneChange("Title");
                }
            );
    }
}
