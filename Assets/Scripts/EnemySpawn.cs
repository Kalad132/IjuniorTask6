using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    private List <Transform> _points;
    private WaitForSeconds _spawnPeriod = new WaitForSeconds(2f);
    private void Awake()
    {
        _points = gameObject.GetComponentsInChildren<Transform>().ToList();
        _points.RemoveAt(0);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int pointIndex = 0;
        while (true)
        {
            GameObject.Instantiate(_template, _points[pointIndex++]);
            if (pointIndex >= _points.Count())
                pointIndex = 0;
            Debug.Log(pointIndex);
            yield return _spawnPeriod;
        }
    }
}
