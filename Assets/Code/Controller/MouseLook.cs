using UnityEngine;


internal class MouseLook : MonoBehaviour
{
    private enum RotationAxes
    {
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField] private RotationAxes _axes = RotationAxes.MouseX;
    [SerializeField] private float _sensitivityHor = 2.0f;
    [SerializeField] private float _sensitivityVert = 2.0f;
    
    private float _minimumVert = -45.0f;
    private float _maximumVert = 45.0f;
    private float _rotationX = 0;
    

    public void Look()
    {
        if (_axes == RotationAxes.MouseX) 
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);
        }
        else if (_axes == RotationAxes.MouseY) 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVert, _maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
    
}
