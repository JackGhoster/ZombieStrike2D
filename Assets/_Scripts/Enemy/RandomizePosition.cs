using UnityEngine;

public class RandomizePosition : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    [SerializeField, Range(1, 20)]
    private float _count;
    [SerializeField, Range(-100, 100)]
    private float _minPosX = 0, _maxPosX = 0, _minPosY = 0, _maxPosY = 0;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            var randomX = Random.Range(_minPosX, _maxPosX);
            var randomY = Random.Range(_minPosY, _maxPosY);
            Vector2 randomPos = new Vector2(randomX, randomY);
            Instantiate(_prefab, randomPos, Quaternion.identity);
        }
        
    }
}
