using Cinemachine;
using UnityEngine;
using TarodevController;
using System;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] public CinemachineVirtualCamera virtualCamera;  // The Cinemachine virtual camera component

    private IPlayerController _playerController;

    private void Awake() => _player.TryGetComponent(out _playerController);

    private void LateUpdate() {
        float projectedPos = 0;
        //CinemachineComponentBase transposer = virtualCamera.GetComponentInChildren<CinemachineFramingTransposer>();
        CinemachineFramingTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        if (_playerController != null) {
            projectedPos = (_playerController.Velocity.normalized).x;
            // _velOffset = Vector3.SmoothDamp(_velOffset, projectedPos, ref _lookAheadVel, _lookAheadSpeed);
        }
        
        if (projectedPos!=0) transposer.m_TrackedObjectOffset.x = projectedPos;

        //Step(_smoothTime);
    }
}
