using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using al = SpGameManager.ActionList;
public class ButtonController : MonoBehaviour
{
    PlayerController playerController;
    CharacterStatus player;
    [SerializeField] Button moveSt, moveR, moveL, moveB;
    Color original;
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (playerController != null) player = playerController.player;
        original = moveSt.GetComponent<Image>().color;
    }
    public void PunchStraight()
    {
        player.status[al.PunchStraight.ToString()] = true;
        Debug.Log("Punch Straight");
    }
    public void PunchLeft()
    {
        player.status[al.PunchLeft.ToString()] = true;
        Debug.Log("Punch Left");
    }
    public void PunchRight()
    {
        player.status[al.PunchRight.ToString()] = true;
        Debug.Log("Punch Right");
    }
    public void MoveStraight()
    {
        player.status[al.MoveStraight.ToString()] = true;
        moveSt.GetComponent<Image>().color = Color.red;
        Debug.Log("Move Straight");
    }
    public void MoveLeft()
    {
        player.status[al.MoveLeft.ToString()] = true;
        moveL.GetComponent<Image>().color = Color.red;
        Debug.Log("Move Left");
    }
    public void MoveRight()
    {
        player.status[al.MoveRight.ToString()] = true;
        moveR.GetComponent<Image>().color = Color.red;
        Debug.Log("Move Right");
    }
    public void MoveBack()
    {
        player.status[al.MoveBack.ToString()] = true;
        moveB.GetComponent<Image>().color = Color.red;
        Debug.Log("Move Back");
    }
    public void Guard()
    {
        player.status[al.Guard.ToString()] = true;
        Debug.Log("Guard");
    }
    public void Cancel()
    {
        player.status[al.CancelLastAction.ToString()] = true;
        Debug.Log("Cancel");
    }

    public void ChangeButtonOriginal()
    {
        Debug.Log("call");
        moveSt.GetComponent<Image>().color = original;
        moveR.GetComponent<Image>().color = original;
        moveL.GetComponent<Image>().color = original;
        moveB.GetComponent<Image>().color = original;
    }
}
