using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffet : MonoBehaviour
{
    private float _speed = 0.01f;
    [SerializeField] private Material _material;

    private void Update()
    {
        _material.mainTextureOffset += new Vector2(0, - Time.deltaTime * _speed);
    }
}
