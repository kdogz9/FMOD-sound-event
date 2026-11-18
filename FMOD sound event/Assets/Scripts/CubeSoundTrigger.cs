
using UnityEngine;
using FMODUnity;

public class CubeSoundTrigger : MonoBehaviour
{
    [SerializeField]
    private EventReference cubeClickEvent;

    
    
    private void Start()
    {
        Debug.Log("CubeSoundTrigger script is running!");
    }

    
    private void OnMouseDown()
    {
        
        RuntimeManager.PlayOneShot(cubeClickEvent);
// plays sound when mouse click is detected 
        
        Debug.Log("FMOD CubeClick event triggered!");
    }

}
