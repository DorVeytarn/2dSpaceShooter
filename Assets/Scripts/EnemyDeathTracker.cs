using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathTracker : MonoBehaviour
{
    public event UnityAction EnemyKilled;


    public void EnemyKilledByPlayer()
    {
        EnemyKilled?.Invoke();
    }
}
