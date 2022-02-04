using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Vector2 _buildingSize;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private int _maxHealth;

    public int MaxHealth { get { return _maxHealth; } set{ _maxHealth = value; } }

    public int CurrentHealth {get; private set;}

    public Vector2 BuildingSize { get => _buildingSize; set {; } }

    private void Awake() {
        CurrentHealth = _maxHealth;
    }

    public void SetColor(bool isAvailableToBuild)
    {
        if (isAvailableToBuild)
            _renderer.material.color = Color.green;
        else
            _renderer.material.color = Color.red;
    }

    public void ResetColor()
    {
        _renderer.material.color = Color.yellow;
    }

    public void ReceiveDamage(int d)
    {
        CurrentHealth -= d;
        if (CurrentHealth < 1)
            DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        Destroy(this.gameObject);
    }
}
