using System.Collections.Generic;
using UnityEngine;

public class Inventory : ScriptableObject
{
    private List<int> _bodyInventery = new List<int>();
    private List<int> _hairInventery = new List<int>();
    private List<int> _torsoInventery = new List<int>();
    private List<int> _legsInvontery = new List<int>();

    public int[] activeCloths = new int[4];

    public int money = 650;

    public bool GetObject(int bodyPart, int partId)
    {
        switch (bodyPart)
        {
            case 0:
                for (int i = 0; i < _bodyInventery.Count; i++)
                {
                    if (partId == _bodyInventery[i])
                        return true;
                }
                return false;
            case 1:
                for (int i = 0; i < _hairInventery.Count; i++)
                {
                    if (partId == _hairInventery[i])
                        return true;
                }
                return false;
            case 2:
                for (int i = 0; i < _torsoInventery.Count; i++)
                {
                    if (partId == _torsoInventery[i])
                        return true;
                }
                return false;
            case 3:
                for (int i = 0; i < _legsInvontery.Count; i++)
                { 
                    if (partId == _legsInvontery[i])
                        return true;
                }
                return false;
            default:
                return false;
        }
    }

    public int GetLength(int bodyPart)
    {
        switch (bodyPart)
        {
            case 0:
                return _bodyInventery.Count;
            case 1:
                return _hairInventery.Count;
            case 2:
                return _torsoInventery.Count;
            case 3:
                return _legsInvontery.Count;
            default:
                return 0;
        }
    }

    public void BuyNewDress(int bodyPart,int partId)
    {
        switch (bodyPart)
        {
            case 0:
                _bodyInventery.Add(partId);
                return;
            case 1:
                _hairInventery.Add(partId);
                return;
            case 2:
                _torsoInventery.Add(partId);
                return;
            case 3:
                _legsInvontery.Add(partId);
                return;
            default:
                return;
        }
    }

    public void SellDress(int bodyPart,int partId)
    {
        switch (bodyPart)
        {
            case 0:
                _bodyInventery.Remove(partId);
                return;
            case 1:
                _hairInventery.Remove(partId);
                return;
            case 2:
                _torsoInventery.Remove(partId);
                return;
            case 3:
                _legsInvontery.Remove(partId);
                return;
            default:
                return;
        }
    }
}
