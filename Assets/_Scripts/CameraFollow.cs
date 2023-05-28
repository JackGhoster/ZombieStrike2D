using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _followTarget;
    private void LateUpdate()
    {
        if(_followTarget) { 
            var pos = new Vector3(_followTarget.position.x, _followTarget.position.y, -10);
            transform.position = pos;
        }
    }
}
