using UnityEngine;

public class Chamber : MonoBehaviour
{
    #region variables

    [Header("how much movement it needs")]
    public float movementNeeded;

    [Header("is it chambered or no?")]
    public bool isChambered;

    //privates
    Vector3 startPos;
    bool hasReached;

    #endregion

    #region start and update

    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        ChecksIfChambered();
    }

    #endregion

    #region check code

    public void ChecksIfChambered()
    {
        float distance = Vector3.Distance(transform.position, startPos);

        if (!isChambered && distance < movementNeeded)
        {
            hasReached = true;
        }

        if (distance == 0.3f && hasReached == true)
        {
            hasReached = false;
            isChambered = true;
        }
    }

    #endregion
}
