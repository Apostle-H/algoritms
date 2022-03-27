using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Room : MonoBehaviour
{
    [Header("Value fields")]
    [SerializeField] private TMP_InputField numberUI;
    [SerializeField] private TMP_InputField habitantNameUI;
    [SerializeField] private Toggle hasAnimalUI;

    private int _number;
    private string _habitantName;
    private bool _hasAnimal;

    private void OnEnable()
    {
        RoomsActions.rooms.Add(this);
    }

    private void Start()
    {
        int.TryParse(numberUI.text, out _number);
        _habitantName = habitantNameUI.text;
        _hasAnimal = hasAnimalUI.isOn;
    }

    public int number { get { return _number; } set { _number = value; numberUI.text = _number.ToString(); } }
    public string habitantName { get { return _habitantName; } set { _habitantName = value; habitantNameUI.text = _habitantName; } }
    public bool hasAnimal { get { return _hasAnimal; } set { _hasAnimal = !_hasAnimal; } }

    public void DestroySelf()
    {
        RoomsActions.rooms.Remove(this);
        Destroy(gameObject);
    }

    public void SetRoomNum(string numString)
    {
        int num;

        if (int.TryParse(numString, out num))
        {
            number = num;
        }
    }
}
