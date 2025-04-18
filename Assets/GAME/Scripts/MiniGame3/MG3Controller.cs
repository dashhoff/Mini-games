using UnityEngine;

public class MG3Controller : MonoBehaviour
{
    [SerializeField] private Transform _logoParent;
    [SerializeField] private Transform _nameParent;

    [SerializeField] private MG3Obj[] _logos;
    [SerializeField] private MG3Obj[] _names;

    [SerializeField] private MG3Obj _selectedLogo;
    [SerializeField] private MG3Obj _selectedName;

    [SerializeField] private int _pair;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        _pair = _logos.Length;

        for (int i = 0; i < _logos.Length; i++)
        {
            _logos[i].Id = i;
            _names[i].Id = i;
        }

        Shuffle();
    }

    /// <summary>
    /// Перемешивание пар
    /// </summary>
    private void Shuffle()
    {
        int count = _logoParent.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform childA = _logoParent.GetChild(i);
            int randomIndex = Random.Range(i, count);
            Transform childB = _logoParent.GetChild(randomIndex);

            childA.SetSiblingIndex(randomIndex);
            childB.SetSiblingIndex(i);
        }

        count = _nameParent.childCount;
        for (int i = 0; i < count; i++)
        {
            Transform childA = _nameParent.GetChild(i);
            int randomIndex = Random.Range(i, count);
            Transform childB = _nameParent.GetChild(randomIndex);

            childA.SetSiblingIndex(randomIndex);
            childB.SetSiblingIndex(i);
        }
    }

    /// <summary>
    /// Клик на лого
    /// </summary>
    public void OnLogoClick(MG3Obj logo)
    {
        _selectedLogo = logo;

        foreach (MG3Obj _logo in _logos)
        {
            _logo.Deselect();
        }

        _selectedLogo.Select();

        CheckPair();
    }

    /// <summary>
    /// Клик на имя
    /// </summary>
    public void OnNameClick(MG3Obj name)
    {
        _selectedName = name;

        foreach (MG3Obj _name in _names)
        {
            _name.Deselect();
        }

        _selectedName.Select();

        CheckPair();
    }

    /// <summary>
    /// Проверка пары
    /// </summary>
    private void CheckPair()
    {
        if (_selectedLogo == null || _selectedName == null) return;

        if (_selectedLogo.Id == _selectedName.Id)
        {
            CorrectPair();
            return;
        }

        if (_selectedLogo.Id != _selectedName.Id)
        {
            WrongPair();
            return;
        }
    }

    /// <summary>
    /// Правильная пара
    /// </summary>
    private void CorrectPair()
    {
        _selectedLogo.gameObject.SetActive(false);
        _selectedName.gameObject.SetActive(false);

        _selectedLogo = null;
        _selectedName = null;

        _pair--;

        MG3EventBus.InvokeCorrectPair();

        if (_pair == 0) Victory();
    }

    /// <summary>
    /// Неправильная пара
    /// </summary>
    private void WrongPair()
    {
        _selectedLogo.Wrong();
        _selectedName.Wrong();

        _selectedLogo = null;
        _selectedName = null;

        MG3EventBus.InvokeWrongPair();
    }

    public void Pause()
    {
        MG3EventBus.InvokePause();
    }

    public void UnPause()
    {
        MG3EventBus.InvokeUnPause();
    }

    /// <summary>
    /// Победа
    /// </summary>
    private void Victory()
    {
        MG3EventBus.InvokeVictory();
    }
}
