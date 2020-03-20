using UnityEngine;
using System.Collections;

public class StoryModeAnimation : MonoBehaviour
{
    public Animator animator;
    StoryModePanel storyMode;


    public void SetupStoryMode(StoryModePanel storyMode)
    {
        this.storyMode = storyMode;
    }

    public void SelectMap()
    {
        animator.Play("ShowMap");
    }
    public void SelectMapKey()
    {
        storyMode.LevelText.text = "Select Level";
    }
    public void PickLevel()
    {
        animator.Play("HideMap");
    }
    public void HideMapKey()
    {
        storyMode.SetLevelText();
    }
}
