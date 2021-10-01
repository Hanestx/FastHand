using FastHand;
using UnityEngine;


internal class CameraController : IExecute
{
    private float _sensitivityHor = 2.0f;
    private float _sensitivityVert = 2.0f;
    
    private float _minimumVert = -45.0f;
    private float _maximumVert = 45.0f;
    private float _rotationX = 0;
    private float _rotationY = 0;
    private Character _player;
    private Camera _mainCamera;

    public CameraController(Character player)
    {
        _player = player;
        _mainCamera = _player.GetComponentInChildren<Camera>();;
    }
    

    public void Execute()
    {
        _player.transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);
        _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
        _rotationY = _mainCamera.transform.localEulerAngles.y;
        _mainCamera.transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
    
}
