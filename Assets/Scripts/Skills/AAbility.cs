using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AAbility : ScriptableObject
{    
    [SerializeField]public bool Ready {get;internal set;} = true;
    public abstract IEnumerator Action(GameObject caster);
}
