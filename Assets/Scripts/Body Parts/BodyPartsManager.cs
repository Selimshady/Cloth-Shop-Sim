using System.Collections.Generic;
using UnityEngine;

public class BodyPartsManager : MonoBehaviour
{
    // ~~ 1. Updates All Animations to Match Player Selections

    [SerializeField] private SO_CharacterBody characterBody;

    // String Arrays
    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;
    
    // Animation
    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        UpdateBodyParts(0, 0); // reset scriptable object
        UpdateBodyParts(1, 0);
        UpdateBodyParts(2, 0);
        UpdateBodyParts(3, 0);
    }

    public void UpdateBodyParts(int bodyPart,int partId)
    {
        string partType = characterBody.characterBodyParts[bodyPart].bodyPartName; // get scriptable body object with animations
        characterBody.characterBodyParts[bodyPart].bodyPart = Resources.Load<SO_BodyPart>("Scriptable Objects/" + partType + "/" + partType + "_" + partId);

        foreach (AnimationClip clip in characterBody.characterBodyParts[bodyPart].bodyPart.allBodyPartAnimations)
        {
            defaultAnimationClips[clip.name.Replace((char)(partId+48),'0')] = clip; // change animations
        }
        animatorOverrideController.ApplyOverrides(defaultAnimationClips); // write over
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}