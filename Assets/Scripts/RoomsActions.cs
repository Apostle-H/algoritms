using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomsActions : MonoBehaviour
{
    public static List<Room> rooms = new List<Room>();

    [SerializeField] private Transform roomsPanel;
    [SerializeField] private GameObject roomPrefab;

    [SerializeField] private TMP_InputField input;

    public void AddRoom()
    {
        Instantiate(roomPrefab, roomsPanel).transform.SetSiblingIndex(roomsPanel.childCount - 2);
    }

    public void HabitantsWithAnimals()
    {
        int counter = 0;

        for (int i = 0; i < rooms.Count; i++)
        {
            if (!rooms[i].hasAnimal)
                continue;

            counter++;
        }

        Debug.Log($"{counter} habitants have animals");
    }

    public void HabitantsWithName()
    {
        int counter = 0;

        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].habitantName.ToLower() != input.text.ToLower())
                continue;

            counter++;
        }

        Debug.Log($"{counter} habitants have name - {input.text}");
    }

    public void OneSignRooms()
    {
        int counter = 0;

        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].number > 9)
                continue;

            counter++;
        }

        Debug.Log($"{counter} habitants have one sign room number");
    }

    public void ReverseHabitants()
    {
        string tempHabitant;
        for (int i = 0, j = rooms.Count - 1; i < rooms.Count / 2; i++, j--)
        {
            tempHabitant = rooms[i].habitantName;
            rooms[i].habitantName = rooms[j].habitantName;
            rooms[j].habitantName = tempHabitant;
        }
    }

    public void RemoveMultipleBy3()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].number % 3 != 0)
                continue;

            rooms[i].DestroySelf();
            i--;
        }
    }

    public void MinimumRoomNumChangeLastWithAnimal()
    {
        int lastHabitantWithAnimal = -1;

        for (int i = rooms.Count - 1; i >= 0; i--)
        {
            if (!rooms[i].hasAnimal)
                continue;

            lastHabitantWithAnimal = i;
            break;
        }

        if (lastHabitantWithAnimal < 0)
            return;

        int habitantWithMinimalRoomNum = 0;
        int minimalRoomNum = rooms[0].number;

        for (int i = 1; i < rooms.Count; i++)
        {
            if (rooms[i].number > minimalRoomNum)
                continue;

            minimalRoomNum = rooms[i].number;
            habitantWithMinimalRoomNum = i;
        }

        string tempHabitant = rooms[habitantWithMinimalRoomNum].habitantName;
        rooms[habitantWithMinimalRoomNum].habitantName = rooms[lastHabitantWithAnimal].habitantName;
        rooms[lastHabitantWithAnimal].habitantName = tempHabitant;
    }
}
