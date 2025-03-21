![Image](https://github.com/user-attachments/assets/8e18e966-9021-432a-b3de-c05179bd113f)

# Getting Started with Cline x Unity

## Cline Setup
Followed the instructions here to install Cline with VS Code: https://docs.cline.bot/getting-started/getting-started-new-coders
- Tip: You don't need "a dedicated folder for all your Cline projects." I just created a repo with GitHub, opened up a new Unity project there, and installed Cline within that project.

Cline worked without a problem once the Unity project was set up with C#, Unity and Cline extensions downloaded.

I purchasesd $5 of API credits from Anthropic and used **Claude 3.7 Sonnet** for this project with Cline

## Using Cline with Unity

Asked Cline (x Claude) to edit the **HelloWorld.cs** empty script to create a smiley face using cubes in realtime. It made a the face but with a frown, and didn't make the right edits after I asked it to fix it to a smile. Then I shared the script with ChatGPT and it fixed the smile immediately. 

**ChatGPT's Response**
>Your frown is caused by the equation used for the smile curve. Right now, you're using a downward-facing parabola:
>
>float y = -0.8f * (t - 0.5f) * (t - 0.5f) + 1.2f;
>
>To make the smile curve upwards instead of downwards, you need to flip the sign of the quadratic term. Try replacing that line with:
>
>float y = 0.8f * (t - 0.5f) * (t - 0.5f) + 1.2f;
>
>This change flips the parabola upwards, creating a proper smile instead of a frown. Let me know if you need further tweaks! 😊

After that it helped me dynamically alter the smiley face in realtime by generating a new script: **SmileyFace.cs**. Check that out for the final version.

**Total Cost: $0.1420**

![Image](https://github.com/user-attachments/assets/83684ea5-88d5-4002-b0cf-20923bdb7248)

## Final Result
![Image](https://github.com/user-attachments/assets/410683c4-9585-4cda-90e9-2bd51c23b8c9)
