using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningState : State
{
    private ResourceCounter _resourceCounter;
    [SerializeField] private int _miningSpeed;

    public int  MiningSpeed { get { return _miningSpeed; } set{ _miningSpeed = value; } }

    private void OnEnable()
    {
        _resourceCounter = ResourceCounter.Instance;
        StartCoroutine(Mine());
    }

    private IEnumerator Mine()
    {
        yield return new WaitForSeconds(2);
        _resourceCounter.ReceiveResources(MiningSpeed);
        StartCoroutine(Mine());
    }
}
