using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAttackingState : State
{
    private Building _attackedBuilding;
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other) {
        Building building = other.GetComponent<Building>();
        if (building != null)
        {
            _attackedBuilding = building;

            StartCoroutine(AttackBuilding());
        }
    }

    private IEnumerator AttackBuilding()
    {
        if (_attackedBuilding.CurrentHealth > 0)
        {
            yield return new WaitForSeconds(1);
            if (_attackedBuilding != null)
                _attackedBuilding.ReceiveDamage(_damage);
            StartCoroutine(AttackBuilding());
        } 
        else 
        {
            _attackedBuilding = null;
            EnemyWalkingTransition enemyWalkingTransition = GetComponent<EnemyWalkingTransition>();
            enemyWalkingTransition.isAbleToGo = true;
        }
    }

    private void Update() {
        
    }
}
