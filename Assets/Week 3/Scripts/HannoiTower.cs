using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HannoiTower : MonoBehaviour
{
    [SerializeField] private Transform peg1Transform;
    [SerializeField] private Transform peg2Transform;
    [SerializeField] private Transform peg3Transform;
    [SerializeField] GameObject Highlight1;
    [SerializeField] GameObject Highlight2;
    [SerializeField] GameObject Highlight3;
    [SerializeField] GameObject WinLabel;

    [SerializeField] private int[] peg1 = { 1, 2, 3, 4 };
    [SerializeField] private int[] peg2 = { 0, 0, 0, 0 };
    [SerializeField] private int[] peg3 = { 0, 0, 0, 0 };

    [SerializeField] private int currentPeg = 1;

    [ContextMenu("Move Right")]
    public void MoveRight()
    {
        
        //Make sure we aren't the right most peg
        if (CanMoveRight() == false) return;

        //Check to see what index and number we are moving from THIS peg
        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        //If there wasn't anything to move then don't try to move
        if (fromIndex == -1) return;

        //Check to see where in the peg we are moving to that the number
        //should be placed into
        int[] toArray = GetPeg(currentPeg + 1);
        int toIndex = GetIndexOfFreeSLot(toArray);

        //If the adjacent peg is FULL then we cannot move anything into it
        //This probably will never happen since the max number of numbers
        //we have is the size of each peg
        if (toIndex == -1) return;

        //Lastly check to verify the number we are moving is not larger
        //than whatever number we may be placing this number on top of
        //on the adjacent peg
        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        //If all checks PASS then go aheand and move the number
        //out of THIS array into the adjacent array
        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg + 1);

        disc.SetParent(toPeg);
        TryEndGame();
    }

    [ContextMenu("Move Left")]
    public void MoveLeft()
    {
        
        //Make sure we aren't the left most peg
        if (CanMoveLeft() == false) return;

        //Check to see what index and number we are moving from THIS peg
        int[] fromArray = GetPeg(currentPeg);
        int fromIndex = GetTopNumberIndex(fromArray);

        //If there wasn't anything to move then don't try to move
        if (fromIndex == -1) return;

        //Check to see where in the peg we are moving to that the number
        //should be placed into
        int[] toArray = GetPeg(currentPeg - 1);
        int toIndex = GetIndexOfFreeSLot(toArray);

        //If the adjacent peg is FULL then we cannot move anything into it
        //This probably will never happen since the max number of numbers
        //we have is the size of each peg
        if (toIndex == -1) return;

        //Lastly check to verify the number we are moving is not larger
        //than whatever number we may be placing this number on top of
        //on the adjacent peg
        if (CanAddToPeg(fromArray[fromIndex], toArray) == false) return;

        //If all checks PASS then go aheand and move the number
        //out of THIS array into the adjacent array
        MoveNumber(fromArray, fromIndex, toArray, toIndex);

        Transform disc = PopDiscFromCurrentPeg();
        Transform toPeg = GetPegTransform(currentPeg - 1);

        disc.SetParent(toPeg);
        TryEndGame();
    }

    public void IncrementPegNumber()
    {
        if (currentPeg != 3)
        currentPeg++;
        DisplayHighlight();
        
    }

    public void DecrementPegNumber()
    {
       if (currentPeg != 1)
        currentPeg--;
        DisplayHighlight();
       
    }

    public void DisplayHighlight()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);

        if (currentPeg == 1)
            Highlight1.SetActive(true);
        
        else if (currentPeg == 2)
        Highlight2.SetActive(true);
        else if (currentPeg == 3)
            Highlight3.SetActive(true);
    }

    public void TryEndGame()
    {
        int[] setToCheck = { 1, 2, 3, 4 };

        // Check if setToCheck is a subset of numbers and in the same order
        bool containsSet = Enumerable.SequenceEqual(
            setToCheck,
            peg3.SkipWhile((x, i) => i < Array.IndexOf(peg3, setToCheck.First())).Take(setToCheck.Length));

        if (containsSet)
        {
            WinLabel.SetActive(true);
        }
        else
        {
            Debug.Log("The array does not contain the specific set of numbers in the same order.");
        }
    }

    Transform PopDiscFromCurrentPeg()
    {
        Transform currentPegTransform = GetPegTransform(currentPeg);
        int index = currentPegTransform.childCount - 1;
        Transform disk = currentPegTransform.GetChild(index);
        return disk;
    }

    Transform GetPegTransform(int pegNumber)
    {
        //Alternative way to find our objects
        //return GameObject.Find($"Peg-{pegNumber}").transform;

        if (pegNumber == 1) return peg1Transform;

        if (pegNumber == 2) return peg2Transform;

        return peg3Transform;
    }

    void MoveNumber(int[] fromArr, int fromIndex, int[] toArr, int toIndex)
    {
        int value = fromArr[fromIndex];
        fromArr[fromIndex] = 0;

        toArr[toIndex] = value;
    }

    bool CanMoveRight()
    {
        //If peg 1 or 2 then can move right
        return currentPeg < 3;
    }

    bool CanAddToPeg(int value, int[] peg)
    {
        int topNumberIndex = GetTopNumberIndex(peg);
        if (topNumberIndex == -1) return true;

        int topNumber = peg[topNumberIndex];
        return topNumber > value;
    }

    bool CanMoveLeft()
    {
        //If peg 2 or 3 then can move right
        return currentPeg > 1;
    }

    int[] GetPeg(int pegNumber)
    {
        if (pegNumber == 1) return peg1;

        if (pegNumber == 2) return peg2;

        return peg3;
    }

    int GetTopNumberIndex(int[] peg)
    {
        for (int i = 0; i < peg.Length; i++)
        {
            if (peg[i] != 0) return i;
        }

        return -1;
    }

    int GetIndexOfFreeSLot(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            if (peg[i] == 0) return i;
        }

        return -1;
    }
}
