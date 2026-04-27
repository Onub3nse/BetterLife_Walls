// Mafi.Core, Version=0.7.8.0, Culture=neutral, PublicKeyToken=null
// Mafi.Core.Factory.Zippers.ZipperSetForceEvenOutputsCmd
using Mafi.Core;
using Mafi.Core.Input;
using Mafi.Serialization;
using System;


[GenerateSerializer(false, null, 0)]
public class blZipperSetForceEvenOutputsCmd : InputCommand
{
    public readonly EntityId ZipperId;

    public readonly bool ForceEvenOutputs;

    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

    public blZipperSetForceEvenOutputsCmd(EntityId zipperId, bool forceEvenOutputs)
    {
        this.ZipperId = zipperId;
        this.ForceEvenOutputs = forceEvenOutputs;
    }

    public static void Serialize(blZipperSetForceEvenOutputsCmd value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, blZipperSetForceEvenOutputsCmd.s_serializeDataDelayedAction);
        }
    }

    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        writer.WriteBool(this.ForceEvenOutputs);
        EntityId.Serialize(this.ZipperId, writer);
    }

    public new static blZipperSetForceEvenOutputsCmd Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out blZipperSetForceEvenOutputsCmd obj, (Func<BlobReader, Type, blZipperSetForceEvenOutputsCmd>)null, (Func<BlobReader, string, blZipperSetForceEvenOutputsCmd>)null, nullObjIsOk: false))
        {
            reader.EnqueueDataDeserialization(obj, blZipperSetForceEvenOutputsCmd.s_deserializeDataDelayedAction);
        }
        return obj;
    }

    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        reader.SetField(this, "ForceEvenOutputs", reader.ReadBool());
        reader.SetField(this, "ZipperId", EntityId.Deserialize(reader));
    }

    static blZipperSetForceEvenOutputsCmd()
    {
        blZipperSetForceEvenOutputsCmd.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((blZipperSetForceEvenOutputsCmd)obj).SerializeData(writer);
        };
        blZipperSetForceEvenOutputsCmd.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((blZipperSetForceEvenOutputsCmd)obj).DeserializeData(reader);
        };
    }
}
