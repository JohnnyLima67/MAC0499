using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class CameraFollowObject : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;

    [Header("Flip Rotation Stats")]
    [SerializeField] private float _flipYRotationTime = 0.5f;

    private Coroutine _turnCoroutine;

    private BoxBoiAnimator _player;


    private void Awake() {
            _player = _playerTransform.gameObject.GetComponent<BoxBoiAnimator>();
    }

    private void Update() {
        transform.position = _playerTransform.position;
    }

    public void CallTurn(float endRotationAmount) {
        _turnCoroutine = StartCoroutine(FlipYLerp(endRotationAmount));
    }

    private IEnumerator FlipYLerp(float endRotationAmount) {
        float startRotation = transform.localEulerAngles.y;
        float yRotation = 0f;

        float elapsedTime = 0f;
        while(elapsedTime == _flipYRotationTime) {
            elapsedTime += Time.deltaTime;

            yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapsedTime / _flipYRotationTime));
            transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

            yield return null;
        }
    }
}
