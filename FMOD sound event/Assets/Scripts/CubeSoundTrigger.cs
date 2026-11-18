using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class CubeSoundTrigger : MonoBehaviour
{
    [SerializeField]
    private EventReference cubeClickEvent;

    private int clickLevel = 0;

    private void OnMouseDown()
    {
        // Create an instance of the FMOD event
        EventInstance sound =
            RuntimeManager.CreateInstance(cubeClickEvent);

        // Set the pitch parameter before playing
        sound.setParameterByName("Click level", clickLevel);

        // Play the sound
        sound.start();

        // Release the instance when playback finishes
        sound.release();

        // Log the event and parameter value
        Debug.Log(
            $"FMOD CubeClick triggered - Click Level: {clickLevel}"
        );

        // Cycle through 0, 1, 2, then back to 0
        clickLevel = (clickLevel + 1) % 3;
    }
}