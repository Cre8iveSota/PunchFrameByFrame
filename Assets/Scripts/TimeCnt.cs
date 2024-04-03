using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using al = SpGameManager.ActionList;

public class TimeCnt
{
    public int excutedTurn;
    public int spentTurn = 0;
    public int necessaryTurn;
    public TimeCnt(int callTurn, al action)
    {
        excutedTurn = callTurn;
        if (
            action == al.PunchLeft || action == al.PunchRight || action == al.PunchStraight
         || action == al.MoveRight || action == al.MoveLeft || action == al.MoveStraight || action == al.MoveBack)
        {
            necessaryTurn = 2;
        }
        else if (action == al.Guard)
        {
            necessaryTurn = 1;
        }
        else if (action == al.CancelLastAction)
        {
            necessaryTurn = 0;
        }
    }
}
