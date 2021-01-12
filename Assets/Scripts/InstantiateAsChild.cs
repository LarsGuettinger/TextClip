using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateAsChild : MonoBehaviour
{
    public GameObject prefab;

    [Button]
    public void SpawnChild()
    {
        Instantiate(prefab, this.transform);
    }
}