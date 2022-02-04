using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPojectile : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } set { _damage = value; } }

    private void Awake() {
        Destroy(this.gameObject, 6f);
    }

    private void FixedUpdate() 
    {
        transform.position += Vector3.right * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        EnemySettings enemySettings = other.GetComponent<EnemySettings>();
        if (enemySettings != null)
        {
            enemySettings.ReceiveDamage(_damage);
            Destroy(this.gameObject);
        }
    }
}
