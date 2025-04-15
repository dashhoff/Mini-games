using UnityEngine;

public class MG2Controller : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnObjects;

    [SerializeField] private Vector2 _spawnCount;
    [SerializeField] private Vector2 _spawnScale;

    [SerializeField] private Transform _parent;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        int spawnCount = Mathf.RoundToInt(Random.Range(_spawnCount.x, _spawnCount.y));

        for (int i = 0; i < spawnCount; i++)
        {
           Spawn();
        }
    }

    /// <summary>
    /// Спавн фигур
    /// </summary>
    private void Spawn()
    {
        GameObject obj = Instantiate(_spawnObjects[Random.Range(0, _spawnObjects.Length)], parent: _parent);

        float objScale = Random.Range(_spawnScale.x, _spawnScale.y);

        obj.transform.localScale = new Vector3(objScale,objScale,objScale);

        SpriteRenderer obgSprite = obj.GetComponent<SpriteRenderer>();
        obgSprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));


    }
}
