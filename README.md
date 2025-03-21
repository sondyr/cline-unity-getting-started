# Getting Started with Cline x Unity

Asked Cline (xClaude) to edit the "HelloWorld.cs" empty script to create a smiley face using cubes in realtime. It made a the face but with a frown, and didn't make the right edits after I asked it to fix it to a smile. Then I shaerd the script with ChatGPT and it fixed the smile immediately. 

**ChatGPT's Response**
>Your frown is caused by the equation used for the smile curve. Right now, you're using a downward-facing parabola:
>
>float y = -1.5f - 0.8f * (t - 0.5f) * (t - 0.5f) + 0.2f;
>
>To make the smile curve upwards instead of downwards, you need to flip the sign of the quadratic term. Try replacing that line with:
>
>float y = -1.5f + 0.8f * (t - 0.5f) * (t - 0.5f) + 0.2f;
>
>This change flips the parabola upwards, creating a proper smile instead of a frown. Let me know if you need further tweaks! 😊

After that it helped me dynamically alter the smiley face in realtime by generating a new script: **SmileyFace.cs**. Check that out for the final version.
