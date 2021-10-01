using UnityEngine;


namespace FastHand
{
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _character;
        private void Start()
        {
            _character = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _character.position + new Vector3(0, 7.5f, 0);
            var renderTexture = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            GetComponent<Camera>().targetTexture = renderTexture;
        }
        private void LateUpdate()
        {
            var newPosition = _character.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _character.eulerAngles.y, 0);
        }
    }
}
