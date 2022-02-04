using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsSetup : MonoBehaviour
{

    [SerializeField] private Building _turret;
    [SerializeField] private TurretPojectile _turretProjectile;

    [SerializeField] private Building _miner;
    [SerializeField] private MiningState _miningState;

    [SerializeField] private JSONController _jsonController;

    private void Awake() {
        SetupMiner();
        SetupTurret();
    }

    private void SetupTurret()
    {
        _turret.MaxHealth = 5 + _jsonController.PlayerStates.TurretLevel;
        _turretProjectile.Damage = 2 + _jsonController.PlayerStates.TurretLevel;
    }

        private void SetupMiner()
    {
        _miner.MaxHealth = 10 + _jsonController.PlayerStates.MinerLevel;
        _miningState.MiningSpeed = 1 + (_jsonController.PlayerStates.MinerLevel / 2);
    }

}
