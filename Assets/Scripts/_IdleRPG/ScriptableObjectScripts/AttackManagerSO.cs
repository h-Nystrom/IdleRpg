using System;
using UnityEngine;

[CreateAssetMenu (menuName = "AttackManager")]
public class AttackManagerSO : ScriptableObject {
    public event Action<AttackManagerSO> ChangeTargetEvent;

    public void UpdateAttackTarget () {
        this.ChangeTargetEvent?.Invoke (this);
    }
}