using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitsActions : MonoBehaviour
{
    public static List<Unit> units = new List<Unit>();

    [SerializeField] private TextMeshProUGUI damageInput;
    [SerializeField] private TextMeshProUGUI hideInput;
    [SerializeField] private TextMeshProUGUI makeBossInput;

    public void HideDamaged()
    {
        int comparingValue;

        if (!int.TryParse(damageInput.text, out comparingValue))
        {
            return;
        }

        foreach (var unit in units)
        {
            if (unit.hp > comparingValue)
                continue;

            unit.gameObject.SetActive(false);
        }
    }

    public void HideWrongLevel()
    {
        int comparingValue;

        if (!int.TryParse(hideInput.text, out comparingValue))
            return;

        foreach (var unit in units)
        {
            if (unit.level == comparingValue)
                continue;

            unit.gameObject.SetActive(false);
        }
    }

    public void RevealAll()
    {
        foreach (var unit in units)
        {
            unit.gameObject.SetActive(true);
        }
    }

    public void MakeBoss()
    {
        foreach (var unit in units)
        {
            if (unit.unitName.ToLower() == makeBossInput.text.ToLower())
            {
                unit.unitName = "Boss";
                unit.hp *= 3;
                unit.level += 1;
            }
        }
    }
}
