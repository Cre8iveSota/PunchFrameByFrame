using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using al = SpGameManager.ActionList;

public class PlayerController : MonoBehaviour
{
    public CharacterStatus player;
    Vector3 direction;
    Quaternion rotation, rotationS, rotationR, rotationL, rotationB;
    SpGameManager spgm;
    int turnExecuted = 0;
    int moveStraightCnt = 3;
    bool isExeMoveSt, isExeMoveR, isExeMoveL, isExeMoveB, isCancel;
    TimeCnt turnInfoMoveSt, turnInfoMoveR, turnInfoMoveL, turnInfoMoveB;
    ButtonController buttonController;

    // Start is called before the first frame update
    void Awake()
    {
        player = new CharacterStatus();
    }
    void Start()
    {
        direction = new Vector3(0, 0, -1);
        rotationS = Quaternion.Euler(0, 0, 0);
        rotationR = Quaternion.Euler(0, 90, 0);
        rotationL = Quaternion.Euler(0, -90, 0);
        rotationB = Quaternion.Euler(0, 180, 0);

        spgm = GameObject.FindGameObjectWithTag("spgm").GetComponent<SpGameManager>();
        buttonController = GameObject.FindGameObjectWithTag("Buttons").GetComponent<ButtonController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerAction(int requestTurn)
    {
        //This function is expected to call every turn;
        Action(requestTurn, al.MoveStraight, ref turnInfoMoveSt, ref isExeMoveSt);
        Action(requestTurn, al.MoveRight, ref turnInfoMoveR, ref isExeMoveR);
        Action(requestTurn, al.MoveLeft, ref turnInfoMoveL, ref isExeMoveL);
        Action(requestTurn, al.MoveBack, ref turnInfoMoveB, ref isExeMoveB);
    }

    private void Action(int requestTurn, al actionType, ref TimeCnt turnInfo, ref bool isExe)
    {
        if (player.status[actionType.ToString()])
        {
            turnInfo = new TimeCnt(requestTurn, actionType);
            player.status[actionType.ToString()] = false;
            isExe = true;
        }
        if (!isCancel && isExe)
        {
            turnInfo.spentTurn++;
            switch (actionType)
            {
                case al.MoveStraight:
                    rotation = rotationS;
                    if (turnInfo.spentTurn == turnInfo.necessaryTurn - 1)
                    {
                        transform.position += rotation * direction / 2;
                        Debug.Log("move st Execution now");
                    }
                    else if (turnInfo.spentTurn == turnInfo.necessaryTurn)
                    {
                        Debug.Log("move st Execution done");
                        transform.position += rotation * direction / 2;
                        turnInfo = null;
                        isExe = false;
                    }
                    break;
                case al.MoveLeft:
                    rotation = rotationL;
                    if (turnInfo.spentTurn == turnInfo.necessaryTurn - 1)
                    {
                        transform.position += rotation * direction / 2;
                        Debug.Log("move l Execution now");
                    }
                    else if (turnInfo.spentTurn == turnInfo.necessaryTurn)
                    {
                        Debug.Log("move l Execution done");
                        transform.position += rotation * direction / 2;
                        turnInfo = null;
                        isExe = false;
                    }
                    break;
                case al.MoveRight:
                    rotation = rotationR;
                    if (turnInfo.spentTurn == turnInfo.necessaryTurn - 1)
                    {
                        transform.position += rotation * direction / 2;
                        Debug.Log("move r Execution now");
                    }
                    else if (turnInfo.spentTurn == turnInfo.necessaryTurn)
                    {
                        Debug.Log("move r Execution done");
                        transform.position += rotation * direction / 2;
                        turnInfo = null;
                        isExe = false;
                    }
                    break;
                case al.MoveBack:
                    rotation = rotationB;
                    if (turnInfo.spentTurn == turnInfo.necessaryTurn - 1)
                    {
                        transform.position += rotation * direction / 2;
                        Debug.Log("move b Execution now");
                    }
                    else if (turnInfo.spentTurn == turnInfo.necessaryTurn)
                    {
                        Debug.Log("move b Execution done");
                        transform.position += rotation * direction / 2;
                        turnInfo = null;
                        isExe = false;
                    }
                    break;
                case al.PunchStraight:
                    Debug.Log("punch straight");
                    break;
                case al.PunchLeft:
                    Debug.Log("punch left");
                    break;
                case al.PunchRight:
                    Debug.Log("punch right");
                    break;
                case al.Guard:
                    Debug.Log("guard");
                    break;
                case al.CancelLastAction:
                    Debug.Log("cancel");
                    break;
            }

        }
        if (turnInfo != null && turnInfo.spentTurn != 0)
        {
            buttonController.ChangeButtonOriginal();
        }
    }

    void EndTurn()
    {
        foreach (var key in player.status.Keys)
        {
            player.status[key] = false;
        }
    }
}
