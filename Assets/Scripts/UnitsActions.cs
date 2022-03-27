using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitsActions : MonoBehaviour
{
    public static List<Unit> units = new List<Unit>();

    [SerializeField] private TMP_InputField input;

    public void HideDamaged()
    {
        int comparingValue;

        if (!int.TryParse(input.text, out comparingValue))
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

        if (!int.TryParse(input.text, out comparingValue))
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
        for (int i = 0; i < units.Count; i++)
        {
            units[i].gameObject.SetActive(true);
        }
    }

    public void MakeBoss()
    {
        foreach (var unit in units)
        {
            if (unit.gameObject.activeSelf && unit.unitName.ToLower() == input.text.ToLower())
            {
                unit.unitName = "Boss";
                unit.hp *= 3;
                unit.level += 1;
            }
        }
    }
}
