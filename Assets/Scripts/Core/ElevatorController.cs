using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum ElevatorState { Idle, Moving }

public class ElevatorController : MonoBehaviour
{
    public int ElevatorID;
    public float moveSpeed = 2f;

    public int CurrentFloor { get; private set; }
    public Direction CurrentDirection { get; private set; }
    public ElevatorState State { get; private set; }

    private List<int> requestQueue = new List<int>();
    private HashSet<int> requestSet = new HashSet<int>();

    private bool isProcessing = false;

    public ElevatorDoor door;

    #region Public API

    public void AddRequest(int floor)
    {
        if (requestSet.Contains(floor))
            return;

        requestQueue.Add(floor);
        requestSet.Add(floor);

        SortQueue();

        if (!isProcessing)
            StartCoroutine(ProcessQueue());
    }

    public bool IsIdle()
    {
        return State == ElevatorState.Idle && requestQueue.Count == 0;
    }

    #endregion

    void SortQueue()
    {
        if (CurrentDirection == Direction.Up)
            requestQueue.Sort((a, b) => a.CompareTo(b));
        else
            requestQueue.Sort((a, b) => b.CompareTo(a));
    }

    IEnumerator ProcessQueue()
    {
        isProcessing = true;

        while (requestQueue.Count > 0)
        {
            int targetFloor = requestQueue[0];
            requestQueue.RemoveAt(0);
            requestSet.Remove(targetFloor);

            //  STEP 1: CLOSE DOOR BEFORE MOVING
            yield return door.CloseDoor();

            //  STEP 2: MOVE
            yield return MoveToFloor(targetFloor);

            //  STEP 3: OPEN DOOR AFTER ARRIVAL
            yield return door.OpenDoor();

            // Optional wait at floor
            yield return new WaitForSeconds(1f);
        }

        State = ElevatorState.Idle;
        isProcessing = false;
    }

    IEnumerator MoveToFloor(int targetFloor)
    {
        State = ElevatorState.Moving;

        float targetY = FloorConfig.Instance.GetY(targetFloor);

        CurrentDirection = (targetFloor > CurrentFloor) ? Direction.Up : Direction.Down;

        float duration = Mathf.Abs(targetFloor - CurrentFloor) / moveSpeed;

        yield return transform.DOMoveY(targetY, duration)
            .SetEase(Ease.Linear)
            .WaitForCompletion();

        CurrentFloor = targetFloor;
    }
}