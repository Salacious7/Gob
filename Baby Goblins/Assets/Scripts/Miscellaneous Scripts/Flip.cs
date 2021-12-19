using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    #region Variables

    #endregion

    public void FlipThis()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
