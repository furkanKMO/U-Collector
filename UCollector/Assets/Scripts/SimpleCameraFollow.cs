using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    private Vector3 _cameraOffset;
    private Transform _playerRef;
    [SerializeField] bool _followZ, _followYZ, _followXYZ;
    void Awake()
    {
        _cameraOffset = transform.position;
        _playerRef = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_followZ)
        {
            transform.position = new Vector3(_cameraOffset.x, _cameraOffset.y, _playerRef.position.z + _cameraOffset.z);
        }
        if (_followYZ)
        {
            transform.position = new Vector3(_cameraOffset.x,_playerRef.position.y+_cameraOffset.y,_playerRef.position.z+_cameraOffset.z);
        }
        if (_followXYZ)
        {
            transform.position = _playerRef.position + _cameraOffset;
        }
    }
}
