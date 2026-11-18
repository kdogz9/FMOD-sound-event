# FMOD sound event dev log

## Introduction (42 words)

The purpose of this project was to understand how audio middleware can be integrated into Unity to create sound events. I decided to use FMOD studio to develop a system where a click sound is played when a square has been pressed. 

## How Was FMOD Integrated into Unity? (138 words)

I chose to use FMOD as it integrates with Unity and allows me to create sound events seperate to the game code. This allows me to change how the audio behaves inside FMOD without having to rewrite the code which triggers it i.e adding parameters rather than using seperate audio files for each variation. 

To integrate FMOD into Unity, I installed FMOD studio alongisde its Unity integration package. I then created an FMOD studio project and linked it to Unity through the set up wizard. This then allowed the events that I created in FMOD to be accessed and triggered in Unity. 

I replaced Unity's audio listener with FMOD's studio listener so FMOD could use the cameras position and orientation when calculating how 3D sounds should be heard if I were to implement these later down the line. 


## What Events Were Triggered and Logged? (152 words)


I created a 2D audio event in FMOD studio called `CubeClick`, which used a short popping sound. To trigger the event, I attached a C# script to a cube inside of Unity. I called `OnMouseDown()` to detect when the player has interacted with the cube which then triggers the sound event in FMOD.

To expand on this task, I decided to research into parameters inside of FMOD to make the popping sound increase in pitch each time it is clicked over the course of 3 clicks. After the third click, the parameter is returned back to its normal value. 

![]()
I used `RuntimeManager.CreateInstance()` to create the audio event and `setParameterByName()` to change the pitch before playing the sound. I also implemented debug outputs so I could see when the event was triggered and the audio changing pitch each time. This helped me confirm that the system was responding correctly to player interactions.

```C# 
private void OnMouseDown()
{
    EventInstance sound =
        RuntimeManager.CreateInstance(cubeClickEvent);

    sound.setParameterByName("Click level", clickLevel);

    sound.start();
    sound.release();

    Debug.Log(
        $"FMOD CubeClick triggered - Click Level: {clickLevel}"
    );

    clickLevel = (clickLevel + 1) % 3;
}
```


**Suggested evidence:** Screenshot of your FMOD pitch automation curve and the `CubeSoundTrigger.cs` script.

## 4. How Was the Middleware Validated in a Packaged Build? (120 words)

**Explain:**
- How you tested the sound inside the Unity Editor.
- How you exported your project as a standalone Windows executable.
- How you launched the `.exe` outside Unity.
- How you verified that clicking the cube triggered the FMOD event.
- How you checked that the pitch variations worked in the final build.
- Why testing outside the Editor is important.

**Sentence starter:**

To validate the FMOD integration, I first tested the audio event within the Unity Editor to ensure that clicking the cube triggered the correct sound...

**Questions to consider:**

- Did the sound work in the standalone build?
- Why is it important to test audio outside Unity?
- What problems could occur if the sound banks weren't included correctly?
- How did you confirm that the middleware was working as intended?

**Suggested evidence:** Screenshot of the standalone Windows build and a short video demonstrating the sound changing when clicked.

## Declaration and sources 

FMOD - Integration Tutorial (s.d.) At: https://www.fmod.com/docs/2.04/unity/integration-tutorial.html (Accessed  18/11/2026).

Playing FMOD Events in Unity (s.d.) At: https://alessandrofama.com/tutorials/fmod/unity/events (Accessed  18/11/2026).

FMOD - Parameters (s.d.) At: https://www.fmod.com/docs/2.03/studio/parameters.html (Accessed  18/11/2026).

FMOD 2.0 & Unity | How To Implement Parameters (2019) Directed by Henry Scott. At: https://www.youtube.com/watch?v=QujIch7TPBU (Accessed  18/11/2026).

Click Sound Music | No Copyright Song & MP3 Free Downloads - Pixabay (s.d.) At: https://pixabay.com/music/search/click%20sound/ (Accessed  18/11/2026). - sound effect used 