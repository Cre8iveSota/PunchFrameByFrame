using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using al = SpGameManager.ActionList;

public class CharacterStatus
{
    public Dictionary<string, bool> status = new Dictionary<string, bool>();
    public CharacterStatus()
    {
        status.Add(al.PunchStraight.ToString(), false);
        status.Add(al.PunchRight.ToString(), false);
        status.Add(al.PunchLeft.ToString(), false);
        status.Add(al.MoveStraight.ToString(), false);
        status.Add(al.MoveRight.ToString(), false);
        status.Add(al.MoveLeft.ToString(), false);
        status.Add(al.MoveBack.ToString(), false);
        status.Add(al.CancelLastAction.ToString(), false);
        status.Add(al.Guard.ToString(), false);
    }
}
