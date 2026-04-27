// Mafi.Core, Version=0.7.8.0, Culture=neutral, PublicKeyToken=null
// Mafi.Core.Factory.Zippers.ZipperSetForceEvenInputsCmd
using Mafi.Core;
using Mafi.Core.Input;
using Mafi.Serialization;
using System;


[GenerateSerializer(false, null, 0)]
public class blZipperSetForceEvenInputsCmd : InputCommand
{
    public readonly EntityId ZipperId;

    public readonly bool ForceEvenInputs;

    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

    public blZipperSetForceEvenInputsCmd(EntityId zipperId, bool forceEvenInputs)
    {
        this.ZipperId = zipperId;
        this.ForceEvenInputs = forceEvenInputs;
    }

    public static void Serialize(blZipperSetForceEvenInputsCmd value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, blZipperSetForceEvenInputsCmd.s_serializeDataDelayedAction);
        }
    }

    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        writer.WriteBool(this.ForceEvenInputs);
        EntityId.Serialize(this.ZipperId, writer);
    }

    public new static blZipperSetForceEvenInputsCmd Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out blZipperSetForceEvenInputsCmd obj, (Func<BlobReader, Type, blZipperSetForceEvenInputsCmd>)null, (Func<BlobReader, string, blZipperSetForceEvenInputsCmd>)null, nullObjIsOk: false))
        {
            reader.EnqueueDataDeserialization(obj, blZipperSetForceEvenInputsCmd.s_deserializeDataDelayedAction);
        }
        return obj;
    }

    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        reader.SetField(this, "ForceEvenInputs", reader.ReadBool());
        reader.SetField(this, "ZipperId", EntityId.Deserialize(reader));
    }

    static blZipperSetForceEvenInputsCmd()
    {

        blZipperSetForceEvenInputsCmd.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((blZipperSetForceEvenInputsCmd)obj).SerializeData(writer);
        };
        blZipperSetForceEvenInputsCmd.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((blZipperSetForceEvenInputsCmd)obj).DeserializeData(reader);
        };
    }
}
