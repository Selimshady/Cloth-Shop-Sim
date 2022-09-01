using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    private List<int> _bodyInventory = new List<int>();
    private List<int> _hairInventory = new List<int>();
    private List<int> _torsoInventory = new List<int>();
    private List<int> _legsInventory = new List<int>();

    public int[] activeCloths = new int[4];

    public int money = 650;

    public bool GetObject(int bodyPart, int partId) // check if it is in the inventory
    {
        switch (bodyPart)
        {
            case 0:
                for (int i = 0; i < _bodyInventory.Count; i++)
                {
                    if (partId == _bodyInventory[i])
                        return true;
                }
                return false;
            case 1:
                for (int i = 0; i < _hairInventory.Count; i++)
                {
                    if (partId == _hairInventory[i])
                        return true;
                }
                return false;
            case 2:
                for (int i = 0; i < _torsoInventory.Count; i++)
                {
                    if (partId == _torsoInventory[i])
                        return true;
                }
                return false;
            case 3:
                for (int i = 0; i < _legsInventory.Count; i++)
                { 
                    if (partId == _legsInventory[i])
                        return true;
                }
                return false;
            default:
                return false;
        }
    }

    public int GetLength(int bodyPart) // check if there are more than one item
    {
        switch (bodyPart)
        {
            case 0:
                return _bodyInventory.Count;
            case 1:
                return _hairInventory.Count;
            case 2:
                return _torsoInventory.Count;
            case 3:
                return _legsInventory.Count;
            default:
                return 0;
        }
    }

    public void BuyNewDress(int bodyPart,int partId) // add to inventory
    {
        switch (bodyPart)
        {
            case 0:
                _bodyInventory.Add(partId);
                return;
            case 1:
                _hairInventory.Add(partId);
                return;
            case 2:
                _torsoInventory.Add(partId);
                return;
            case 3:
                _legsInventory.Add(partId);
                return;
            default:
                return;
        }
    }

    public void SellDress(int bodyPart,int partId) // remove from invventory
    {
        switch (bodyPart)
        {
            case 0:
                _bodyInventory.Remove(partId);
                return;
            case 1:
                _hairInventory.Remove(partId);
                return;
            case 2:
                _torsoInventory.Remove(partId);
                return;
            case 3:
                _legsInventory.Remove(partId);
                return;
            default:
                return;
        }
    }
}
