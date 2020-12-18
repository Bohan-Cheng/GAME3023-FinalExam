using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Misc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hide", 5.0f);
    }

    // Update is called once per frame
    void Hide()
    {
        gameObject.SetActive(false);
    }
}
