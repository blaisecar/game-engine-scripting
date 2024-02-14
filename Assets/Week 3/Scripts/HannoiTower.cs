using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HannoiTower : MonoBehaviour
{
    int[] peg1 = { 1, 2, 3, 4, 5, 6, 7, 8 };
    int[] peg2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] peg3 = { 0, 0, 0, 0, 0, 0, 0, 0 };

    int currentPeg = 1;

    void MoveRight()
    {
        int[] currentList = GetPeg(currentPeg);
        int[] targetList = GetPeg(currentPeg + 1);

        if (targetList == null) return;

        int fromIndex = getTopNumberIndex(currentList);
        int toIndex = getBottomNumberIndex(targetList);

        if (toIndex == -1) return;
        if (CanMoveIntoPeg(currentList[fromIndex], currentList) == false) return;

      //  MoveIntoPeg(fromIndex, toIndex, currentList, targetList);
    }

    int getTopNumberIndex(int[] peg)
    {
        for(int i= 0; i < peg.Length; i++)
        {
            //if index value for peg isn't a 0
            if (peg[i] != 0) return i;
        }

        return -1;
    }

    int getBottomNumberIndex(int[] peg)
    {
        for (int i = peg.Length - 1; i >= 0; i--)
        {
            //if index value for peg isn't a 0
            if (peg[i] == 0) return i;
        }

        return -1;
    }

    bool CanMoveIntoPeg(int numberToMove, int[] peg)
    {
       
       int bottomIndex = getBottomNumberIndex(peg);

        if (bottomIndex == peg.Length - 1 && peg[peg.Length-1] == 0) return true;

        int bottomPlus1 = bottomIndex + 1;

        return bottomPlus1 == 0;
        

    }

    void MoveIntoPeg(int fromIndex, int[] from, int[] to, int toIndex)
    {
        int numberToMove = from[fromIndex];
        from[fromIndex] = 0;
        to[toIndex] = numberToMove;
    }

    int[] GetPeg(int peg)
    {
        if (currentPeg == 1) return peg1;
        else if (currentPeg == 2) return peg2;
        if (currentPeg == 3) return peg3;
       
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
