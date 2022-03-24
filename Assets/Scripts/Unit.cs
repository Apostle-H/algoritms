using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    [Header("Value fields")]
    [SerializeField] private TextMeshProUGUI nameUI;
    [SerializeField] private TextMeshProUGUI hpUI;
    [SerializeField] private TextMeshProUGUI levelUI;

    private string _unitName;
    private int _hp;
    private int _level;

    private void OnEnable()
    {
        UnitsActions.units.Add(this);
    }

    private void Start()
    {
        _unitName = nameUI.text;
        _hp =  int.Parse(hpUI.text);
        _level =  int.Parse(levelUI.text);
    }

    public string unitName { get { return _unitName; } set { _unitName = value; nameUI.text = _unitName; } }
    public int hp { get { return _hp; } set { _hp = value; hpUI.text = _hp.ToString(); } }
    public int level { get { return _level ; } set { _level = value; levelUI.text = _level.ToString(); } }
}
