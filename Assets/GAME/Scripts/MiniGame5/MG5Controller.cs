using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MG5Controller : MonoBehaviour
{
    [SerializeField] private GameObject _startFace;
    [SerializeField] private GameObject _mainWindow;

    [SerializeField] private Sprite[] _faces;
    [SerializeField] private Sprite[] _hairStyles;
    [SerializeField] private Sprite[] _glasses;
    [SerializeField] private Sprite[] _eyes;
    [SerializeField] private Sprite[] _noses;
    [SerializeField] private Sprite[] _mouthes;

    [SerializeField] private Image _face;
    [SerializeField] private Image _hairStyle;
    [SerializeField] private Image _glass;
    [SerializeField] private Image[] _eye;
    [SerializeField] private Image _nose;
    [SerializeField] private Image _mouth;

    [SerializeField] private float _startDelay;

    [SerializeField] private int _faceId;
    [SerializeField] private int _hairId;
    [SerializeField] private int _glassId;
    [SerializeField] private int _eyeId;
    [SerializeField] private int _noseId;
    [SerializeField] private int _mouthId;

    [SerializeField] private int _temporaryFaceId;
    [SerializeField] private int _temporaryHairId;
    [SerializeField] private int _temporaryGlassId;
    [SerializeField] private int _temporaryEyeId;
    [SerializeField] private int _temporaryNoseId;
    [SerializeField] private int _temporaryMouthId;

    [SerializeField] private int _objIndex = 0;

    [SerializeField] private TMP_Text _objText;
    [SerializeField] private TMP_Text _indexText;

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Èíèöèàëèçàöèÿ
    /// </summary>
    public void Init()
    {
        GenerateFace();
        Invoke("StartGame", _startDelay);
    }

    private void GenerateFace()
    {
        _faceId = Random.Range(0, _faces.Length);
        _face.sprite = _faces[_faceId];

        _hairId = Random.Range(0, _hairStyles.Length);
        _hairStyle.sprite = _hairStyles[_hairId];

        _glassId = Random.Range(0, _glasses.Length);
        _glass.sprite = _glasses[_glassId];

        _eyeId = Random.Range(0, _eyes.Length);
        _eye[0].sprite = _eyes[_eyeId];
        _eye[1].sprite = _eyes[_eyeId];

        _noseId = Random.Range(0, _noses.Length);
        _nose.sprite = _noses[_noseId];

        _mouthId = Random.Range(0, _mouthes.Length);
        _mouth.sprite = _mouthes[_mouthId];
    }

    public void ChangeObj(bool next)
    {
        if (next)
            _objIndex++;
        else
            _objIndex--;

        if (_objIndex > 5)
            _objIndex = 0;

        if (_objIndex < 0)
            _objIndex = 5;

        switch (_objIndex)
        {
            case 0:
                _objText.text = "ÃÎËÎÂÀ";
                break;
            case 1:
                _objText.text = "ÂÎËÎÑÛ";
                break;
            case 2:
                _objText.text = "Î×ÊÈ";

                break;
            case 3:
                _objText.text = "ÃËÀÇÀ";
                break;
            case 4:
                _objText.text = "ÍÎÑ";
                break;
            case 5:
                _objText.text = "ÐÎÒ";
                break;
        }
    }

    public void ChangeIndex(bool next)
    {
        switch (_objIndex)
        {
            case 0: //face
                if (next)
                    _temporaryFaceId++;
                else
                    _temporaryFaceId--;

                if (_temporaryFaceId >= _faces.Length)
                    _temporaryFaceId = 0;

                if (_temporaryFaceId < 0)
                    _temporaryFaceId = _faces.Length;

                _indexText.text = _temporaryFaceId.ToString();
                break;
            case 1: //hair
                if (next)
                    _temporaryHairId++;
                else
                    _temporaryHairId--;

                if (_temporaryHairId >= _hairStyles.Length)
                    _temporaryHairId = 0;

                if (_temporaryHairId < 0)
                    _temporaryHairId = _hairStyles.Length;

                _indexText.text = _temporaryHairId.ToString();
                break;
            case 2: //glass
                if (next)
                    _temporaryGlassId++;
                else
                    _temporaryGlassId--;

                if (_temporaryGlassId >= _glasses.Length)
                    _temporaryGlassId = 0;

                if (_temporaryGlassId < 0)
                    _temporaryGlassId = _glasses.Length;

                _indexText.text = _temporaryGlassId.ToString();
                break;
            case 3: //eye
                if (next)
                    _temporaryEyeId++;
                else
                    _temporaryEyeId--;

                if (_temporaryEyeId >= _faces.Length)
                    _temporaryEyeId = 0;

                if (_temporaryEyeId < 0)
                    _temporaryEyeId = _faces.Length;

                _indexText.text = _temporaryEyeId.ToString();
                break;
            case 4: //nose
                if (next)
                    _temporaryNoseId++;
                else
                    _temporaryNoseId--;

                if (_temporaryNoseId >= _noses.Length)
                    _temporaryNoseId = 0;

                if (_temporaryNoseId < 0)
                    _temporaryNoseId = _noses.Length;

                _indexText.text = _temporaryNoseId.ToString();
                break;
            case 5: //mouth
                if (next)
                    _temporaryMouthId++;
                else
                    _temporaryMouthId--;

                if (_temporaryMouthId >= _mouthes.Length)
                    _temporaryMouthId = 0;

                if (_temporaryMouthId < 0)
                    _temporaryMouthId = _mouthes.Length;

                _indexText.text = _temporaryMouthId.ToString();
                break;
        }
        ChangeFace();
    }

    private void ChangeFace()
    {
        _face.sprite = _faces[_temporaryFaceId];
        _hairStyle.sprite = _hairStyles[_temporaryHairId];
        _glass.sprite = _glasses[_temporaryGlassId];
        _eye[0].sprite = _eyes[_temporaryEyeId];
        _eye[1].sprite = _eyes[_temporaryEyeId];
        _nose.sprite = _noses[_temporaryNoseId];
        _mouth.sprite = _mouthes[_temporaryMouthId];
    }

    private void StartGame()
    {
        _mainWindow.SetActive(true);
        _startFace.SetActive(false);

        MG5EventBus.InvokeStartGame();
    }

    public void Pause()
    {
        MG5EventBus.InvokePause();
    }

    public void UnPause()
    {
        MG5EventBus.InvokeUnPause();
    }

    private void Correct()
    {
        MG5EventBus.InvokeCorrect();
    }

    private void Wrong()
    {
        MG5EventBus.InvokeWrong();
    }

    private void Victory()
    {
        MG5EventBus.InvokeVictory();
    }
}
