using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MG1Controller : MonoBehaviour
{
    [SerializeField] private bool _canPaint = true;

    [SerializeField] private List<Color> _colors;
    [SerializeField] private int _selectedColorId;
    [SerializeField] private Color _selectedColor;

    [SerializeField] private int[] _spritesColorId;
    [SerializeField] private Image[] _sprites;
    [SerializeField] private bool[] _fullColored;

    private void OnEnable()
    {
        MG1EventBus.OnVictory += () => { _canPaint = false; };
    }

    private void OnDisable()
    {
        MG1EventBus.OnVictory -= () => { _canPaint = false; };
    }

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        _fullColored = new bool[_sprites.Length];
    }

    /// <summary>
    /// Попробовать закрасить
    /// </summary>
    public void TryPaint(int id)
    {
        if (!_canPaint) return;

        if (_selectedColorId == _spritesColorId[id])
            Paint(id);
    }

    /// <summary>
    /// Заскрасить
    /// </summary>
    public void Paint(int id)
    {
        Color color = _selectedColor;
        color.a = 256;

        _sprites[id].color = color;
        _fullColored[id] = true;

        CheckFull();
    }

    /// <summary>
    /// Проверка на то что все картинки закрашены
    /// </summary>
    private void CheckFull()
    {
        for (int i = 0; i < _fullColored.Length; i++)
        {
            if (!_fullColored[i])
                return;
        }

        MG1EventBus.InvokeVictory();
    }

    /// <summary>
    /// Выбрать цвет
    /// </summary>
    public void SelectColor(int id)
    {
        _selectedColorId = id;
        _selectedColor = _colors[id];
    }
}
