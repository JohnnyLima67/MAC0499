using Cinemachine;
using UnityEngine;
using TarodevController;
using System;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] public CinemachineVirtualCamera virtualCamera;  // The Cinemachine virtual camera component

    private IPlayerController _playerController;
    private float fallTime = 0f;

    private void Awake() => _player.TryGetComponent(out _playerController);

    private void LateUpdate() {
        float projectedPosx = 0;
        float projectedPosy = 0;
        //CinemachineComponentBase transposer = virtualCamera.GetComponentInChildren<CinemachineFramingTransposer>();
        CinemachineFramingTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (_playerController != null) {
            projectedPosx = (_playerController.Velocity.normalized).x;
            if ((_playerController.Velocity).y < 0) projectedPosy = 0.6f; 
            // _velOffset = Vector3.SmoothDamp(_velOffset, projectedPos, ref _lookAheadVel, _lookAheadSpeed);
        }
        
        if (projectedPosx!=0) transposer.m_TrackedObjectOffset.x = projectedPosx;
        if (_playerController.Velocity.y < -20) transposer.m_YDamping = projectedPosy;
        else transposer.m_YDamping = 1;
        Debug.Log(projectedPosy);

        //Step(_smoothTime);
    }
}
