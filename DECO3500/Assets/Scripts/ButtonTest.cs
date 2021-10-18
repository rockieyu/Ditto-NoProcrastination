using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{

    [SerializeField] GameObject buttonResult;
    [SerializeField] bool isShown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForShow();
    }

    public void clickthis()
    {
        isShown = !isShown;
    }

    void CheckForShow()
    {

        buttonResult.SetActive(isShown);

    }

    
}
