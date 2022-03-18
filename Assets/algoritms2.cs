using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class algoritms2 : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    [SerializeField] private float spacing;

    virtual protected void Start()
    {
        int n = cubes.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (cubes[j].localScale.magnitude < cubes[j + 1].localScale.magnitude)
                {
                    Transform temp = cubes[j];
                    cubes[j] = cubes[j + 1];
                    cubes[j + 1] = temp;
                }
            }                
        }

        Vector3 spawnPoint = Vector3.zero;
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].position = spawnPoint;
            spawnPoint.x += (cubes[i].localScale.x / 2) + spacing + ((i + 1 < cubes.Length ? cubes[i + 1].localScale.x : 0) / 2);
        }
    }
}
