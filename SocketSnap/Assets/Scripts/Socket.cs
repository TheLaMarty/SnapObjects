using UnityEngine;

public class Socket : MonoBehaviour
{
    public PuzzlePiece PuzzlePiece;
    public bool correctPiecePlaced;

    PuzzleManager puzzleManager;
    float turningRate = 10f;
    bool hasBeenChecked;

    void Awake()
    {
        puzzleManager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Vector3.Dot(gameObject.transform.forward, other.transform.forward) >= 0.5 && (Vector3.Distance(gameObject.transform.position, other.transform.position) <= 0.5))
        {
            SnapObject(other);
        }

        if(!hasBeenChecked){
            CheckPuzzlePiece(other);
            hasBeenChecked = true;
            Debug.Log(hasBeenChecked);
        }
    }

    private void SnapObject(Collider other)
    {
        other.transform.rotation = Quaternion.Slerp(other.transform.rotation, gameObject.transform.rotation, Time.deltaTime * turningRate);
        other.transform.position = Vector3.Lerp(other.transform.position, gameObject.transform.position, Time.deltaTime * turningRate);

        //TODO VRTK Interactable Object?
        other.GetComponent<Rigidbody>().Sleep();
        if (other.transform.rotation == gameObject.transform.rotation && other.transform.position == gameObject.transform.position)
        {
            other.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }

    public void CheckPuzzlePiece(Collider other)
    {
        if (other.GetComponent<PuzzlePiece>() == PuzzlePiece.GetComponent<PuzzlePiece>())
        {
            correctPiecePlaced = true;
            puzzleManager.CheckIfPuzzleIsSolved();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        correctPiecePlaced = false;
        other.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        hasBeenChecked = false;
        Debug.Log(hasBeenChecked);
    }
}
