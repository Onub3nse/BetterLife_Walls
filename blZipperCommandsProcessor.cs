// Mafi.Core, Version=0.7.8.0, Culture=neutral, PublicKeyToken=null
// Mafi.Core.Factory.Zippers.ZipperCommandsProcessor
using BetterLife;
using Mafi;
using Mafi.Core.Entities;
using Mafi.Core.Input;

[GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
internal class blZipperCommandsProcessor : ICommandProcessor<blZipperSetPriorityPortsCmd>, IAction<blZipperSetPriorityPortsCmd>, ICommandProcessor<blZipperSetForceEvenInputsCmd>, IAction<blZipperSetForceEvenInputsCmd>, ICommandProcessor<blZipperSetForceEvenOutputsCmd>, IAction<blZipperSetForceEvenOutputsCmd>
{
    private readonly EntitiesManager m_entitiesManager;

    public blZipperCommandsProcessor(EntitiesManager entitiesManager)
    {
        this.m_entitiesManager = entitiesManager;
    }

    public void Invoke(blZipperSetPriorityPortsCmd cmd)
    {
        if (!this.m_entitiesManager.TryGetEntity<blZipper>(cmd.ZipperId, out var entity))
        {
            cmd.SetResultError($"BL Zipper entity '{cmd.ZipperId}' was not found.");
        }
        else if (entity.TrySetPortPriorityForPort(cmd.PortName, cmd.IsPrioritized))
        {
            cmd.SetResultSuccess();
        }
        else
        {
            cmd.SetResultError("Failed to find port to prioritize.");
        }
    }

    public void Invoke(blZipperSetForceEvenInputsCmd cmd)
    {
        if (!this.m_entitiesManager.TryGetEntity<blZipper>(cmd.ZipperId, out var entity))
        {
            cmd.SetResultError($"BL Zipper entity '{cmd.ZipperId}' was not found.");
            return;
        }
        entity.SetForceEvenInputs(cmd.ForceEvenInputs);
        cmd.SetResultSuccess();
    }

    public void Invoke(blZipperSetForceEvenOutputsCmd cmd)
    {
        if (!this.m_entitiesManager.TryGetEntity<blZipper>(cmd.ZipperId, out var entity))
        {
            cmd.SetResultError($"BL Zipper entity '{cmd.ZipperId}' was not found.");
            return;
        }
        entity.SetForceEvenOutputs(cmd.ForceEvenOutputs);
        cmd.SetResultSuccess();
    }
}