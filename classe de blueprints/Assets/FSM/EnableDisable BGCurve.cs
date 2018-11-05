using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Name("Enable BG")]
[Category("Custom")]

public class EnableDisableBGCurve : ActionTask {

    public GameObject bgCurve;

    protected override void OnExecute()
    {
        bgCurve.SetActive(true);
    }

    protected override void OnStop()
    {
        bgCurve.SetActive(false);
    }
}
