using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class SpGameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text turn;
    [SerializeField] private int decisionPeriodms = 3000;
    public int turnCnt;
    private float timeElapsed;
    GameObject playerObj;
    PlayerController player;
    CharacterStatus cs;
    public enum ActionList { PunchStraight = 0, PunchLeft = 1, PunchRight = 2, MoveStraight = 3, MoveRight = 4, MoveLeft = 5, MoveBack = 6, CancelLastAction = 7, Guard = 8 }
    // Start is called before the first frame update
    async void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.GetComponent<PlayerController>();
            cs = player.player;
        }

        await UniTask.Delay(decisionPeriodms);
        while (true)
        {
            player.PlayerAction(turnCnt);
            turnCnt++;
            if (turn != null) turn.text = $"Turn: {turnCnt}";
            await UniTask.Delay(decisionPeriodms);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var i in cs.status)
            {
                Debug.Log($"{i.Key}: {i.Value}..");
            }
        }
    }
}
