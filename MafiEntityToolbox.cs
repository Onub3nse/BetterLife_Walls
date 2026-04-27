using Mafi;
using Mafi.Core;
using Mafi.Localization;
using Mafi.Unity.Audio;
using Mafi.Unity.InputControl;
using Mafi.Unity.Ui.Hud;
using System;
using UnityEngine;
[GlobalDependency(RegistrationMode.AsEverything)]
public class blLayoutEntityToolbox : Toolbox
{
    public ToolboxItem DoNotCopyConfigBtn { get; set; }
    public ToolboxItem PlaceMultipleBtn { get; set; }
    private readonly AudioSource m_downSound;
    private readonly AudioSource m_invalidSound;
    private Option<Func<bool?>> m_onDown;
    private Option<Action> m_onFlip;
    private Option<Action> m_onRotate;
    private Option<Action> m_onToggleSnapping;
    private Option<Action> m_onToggleZipperPlacement;
    private Option<Func<bool?>> m_onUp;
    private readonly AudioSource m_rotateSound;
    private readonly ToolboxItem m_snappingBtn;
    private readonly AudioSource m_upSound;
    private readonly ToolboxItem m_zipperBtn;
    public blLayoutEntityToolbox(ToolbarHud hud, ShortcutsManager shortcutsManager, AudioDb audioDb) : base(shortcutsManager)
    {
        this.m_invalidSound = audioDb.GetSharedAudioUi("Assets/Unity/UserInterface/Audio/InvalidOp.prefab");
        this.m_upSound = audioDb.GetSharedAudioUi("Assets/Unity/UserInterface/Audio/Up.prefab");
        this.m_downSound = audioDb.GetSharedAudioUi("Assets/Unity/UserInterface/Audio/Down.prefab");
        this.m_rotateSound = audioDb.GetSharedAudioUi("Assets/Unity/UserInterface/Audio/Rotate.prefab");
        base.AddEntry("Assets/Unity/UserInterface/General/Rotate128.png", (ShortcutsManager m) => m.Rotate, delegate
        {
            if (this.m_onRotate.HasValue)
            {
                this.m_onRotate.Value();
            }
        }, new LocStrFormatted?(Tr.RotateShortcut__Tooltip));
        base.AddEntry("Assets/Unity/UserInterface/General/Flip128.png", (ShortcutsManager m) => m.Flip, delegate
        {
            if (this.m_onFlip.HasValue)
            {
                this.m_onFlip.Value();
            }
        }, new LocStrFormatted?(Tr.FlipShortcut__Tooltip));
        this.PlaceMultipleBtn = base.AddEntry("Assets/Unity/UserInterface/General/Repeat.svg", (ShortcutsManager m) => m.PlaceMultiple, delegate
        {
        }, new LocStrFormatted?(Tr.PlaceMultipleTooltip));
        this.DoNotCopyConfigBtn = base.AddEntry("Assets/Unity/UserInterface/Toolbox/DoNotCopy.svg", (ShortcutsManager m) => m.CopyExcludingSettings, null, new LocStrFormatted?(Tr.CopyTool__NoCopyTooltip));
        base.AddEntry("Assets/Unity/UserInterface/General/PlatformUp128.png", (ShortcutsManager m) => m.RaiseUp, new Action(this.OnUp), null);
        base.AddEntry("Assets/Unity/UserInterface/General/PlatformDown128.png", (ShortcutsManager m) => m.LowerDown, new Action(this.OnDown), null);
        this.m_snappingBtn = base.AddEntry("Assets/Unity/UserInterface/Toolbox/NoSnap.svg", (ShortcutsManager m) => m.LiftSnapping, new Action(this.OnTogglePortSnapping), new LocStrFormatted?(Tr.TransportTool__PortSnapTooltip));
        base.SetEntryVisible(this.m_snappingBtn, false);
        this.m_zipperBtn = base.AddEntry("TODO", (ShortcutsManager m) => m.TransportPortsBlocking, new Action(this.OnZipperPlacement), new LocStrFormatted?(Tr.TransportTool__PortSnapTooltip));
        base.SetEntryVisible(this.m_zipperBtn, false);
        hud.AddToolbox(this);
    }

    public void DisplaySnappingDisabled(bool isDisabled)
    {
        this.m_snappingBtn.Selected(isDisabled);
    }

    public void OnDown()
    {
        if (this.m_onDown.IsNone)
        {
            return;
        }
        bool? flag = this.m_onDown.Value();
        this.PlayDownSound(flag);
    }

    public void OnTogglePortSnapping()
    {
        if (!this.m_snappingBtn.IsVisible())
        {
            return;
        }
        if (this.m_onToggleSnapping.IsNone)
        {
            return;
        }
        this.m_onToggleSnapping.Value();
        this.m_rotateSound.Play();
    }

    public void OnUp()
    {
        if (this.m_onUp.IsNone)
        {
            return;
        }
        bool? flag = this.m_onUp.Value();
        this.PlayUpSound(flag);
    }
    public void OnZipperPlacement()
    {
        if (!this.m_zipperBtn.IsVisible())
        {
            return;
        }
        if (this.m_onToggleZipperPlacement.IsNone)
        {
            return;
        }
        this.m_onToggleZipperPlacement.Value();
        this.m_rotateSound.Play();
    }
    public void PlayDownSound(bool? success)
    {
        if (success.GetValueOrDefault())
        {
            this.m_downSound.Play();
            return;
        }
        bool? flag = success;
        bool flag2 = false;
        if ((flag.GetValueOrDefault() == flag2) & (flag != null))
        {
            this.m_invalidSound.Play();
        }
    }
    public void PlayUpSound(bool? success)
    {
        if (success.GetValueOrDefault())
        {
            this.m_upSound.Play();
            return;
        }
        bool? flag = success;
        bool flag2 = false;
        if ((flag.GetValueOrDefault() == flag2) & (flag != null))
        {
            this.m_invalidSound.Play();
        }
    }
    public void SetDoNotCopyConfigVisibility(bool isVisible)
    {
        base.SetEntryVisible(this.DoNotCopyConfigBtn, isVisible);
    }
    public void SetOnDown(Func<bool?> action)
    {
        Assert.That<Option<Func<bool?>>>(this.m_onDown).IsNone("");
        this.m_onDown = action;
    }
    public void SetOnFlip(Action action)
    {
        Assert.That<Option<Action>>(this.m_onFlip).IsNone("");
        this.m_onFlip = action;
    }
    public void SetOnRotate(Action action)
    {
        Assert.That<Option<Action>>(this.m_onRotate).IsNone("");
        this.m_onRotate = action;
    }
    public void SetOnToggleSnapping(Action action)
    {
        this.m_onToggleSnapping = action;
    }
    public void SetOnToggleZipperPlacement(Action action)
    {
        this.m_onToggleZipperPlacement = action;
    }
    public void SetOnUp(Func<bool?> action)
    {
        Assert.That<Option<Func<bool?>>>(this.m_onUp).IsNone("");
        this.m_onUp = action;
    }
    public void SetPortSnappingButtonEnabled(bool enabled)
    {
        base.SetEntryVisible(this.m_snappingBtn, enabled);
    }
}
