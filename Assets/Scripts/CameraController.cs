using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private bool _followCam = true;
    private Vector3 _startDistance, _moveVec;

    void Start()
    {
        _startDistance = transform.position;
    }

    void Update()
    {
        if (_followCam)
        {
            _moveVec.y = _startDistance.y;
            _moveVec.x = Mathf.Lerp(transform.position.x, _player.transform.position.x, 5f * Time.deltaTime);
            _moveVec.z = Mathf.Lerp(transform.position.z, _player.transform.position.z - 6f, 5f * Time.deltaTime);
            transform.position = _moveVec;
        }
    }
}
