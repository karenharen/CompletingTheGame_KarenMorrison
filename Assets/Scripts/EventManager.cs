using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [System.Serializable] public class TargetDestoryed : UnityEvent<int> { }
    public TargetDestoryed targetDestoryed;


    public UnityEvent gameOverEvent;
}
