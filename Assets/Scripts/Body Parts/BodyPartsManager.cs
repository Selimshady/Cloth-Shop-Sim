using System.Collections.Generic;
using UnityEngine;

public class BodyPartsManager : MonoBehaviour
{
    // ~~ 1. Updates All Animations to Match Player Selections

    public static BodyPartsManager instance;

    [SerializeField] private SO_CharacterBody characterBody;

    // Animation
    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    public static Inventory inventory;

    private void Awake()
    {
        inventory = ScriptableObject.CreateInstance<Inventory>();
        instance = this;
    }

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);


        Buy(0, 0);
        Buy(1, 0);
        Buy(2, 0);
        Buy(3, 0);
        UpdateBodyParts(0, 0); // reset scriptable object 
        UpdateBodyParts(1, 0); // initialize
        UpdateBodyParts(2, 0);
        UpdateBodyParts(3, 0);
    }

    public void UpdateBodyParts(int bodyPart,int partId)
    {
        inventory.activeCloths[bodyPart] = partId;

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

    public bool Buy(int bodyPart, int partId)
    {
        if (inventory.money >= 100)
        {
            inventory.BuyNewDress(bodyPart, partId);// adding into inventory
            inventory.money -= 100;
            return true;
        }
        else
            return false;
    }
    public bool Sell(int bodyPart, int partId)
    {
        if (inventory.GetLength(bodyPart) > 1 && inventory.activeCloths[bodyPart] != partId)
        {
            inventory.money += 50;
            inventory.SellDress(bodyPart, partId);// removing from inventory
            return true;
        }
        return false;
    }

    public bool Dress(int bodyPart, int partId)
    {
        if(inventory.activeCloths[bodyPart] != partId) // write over only if it is different
        {
            UpdateBodyParts(bodyPart, partId);
            return true;
        }
        return false;
    }

}