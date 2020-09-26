using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class TitleDirector : DirectorBase, ITitleDirector
{
    public void ChangeSceneStart()
    {
        executeSceneChange("Title", "Ingame");
    }
}
