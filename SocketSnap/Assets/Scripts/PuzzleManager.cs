using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Socket[] Sockets;

    public void CheckIfPuzzleIsSolved()

    {
        bool puzzleSolved = true;

        for (int i = 0; i < Sockets.Length; i++)
        {
            if (!Sockets[i].correctPiecePlaced)
            {
                puzzleSolved = false;
                break;
            }
        }
        if (puzzleSolved)
        {
            
            Debug.Log("Puzzle is solved!");
            //foreach (Socket socket in Sockets)
            {
                //TODO disable interactable objects
            }
        }
    }

    /*
    int counter = 0;

    for (int i = 0; i < Sockets.Length; i++)
    {
        if (Sockets[i].correctPiecePlaced)
        {
            counter++;
        }
        if (counter == Sockets.Length)
        {
            Debug.Log("Puzzle is solved!");
            //foreach (Socket socket in Sockets)
            {
                //TODO disable interactable objects
            }
        }
    }*/
}

