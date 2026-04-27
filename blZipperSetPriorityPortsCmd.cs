// Mafi.Core, Version=0.7.8.0, Culture=neutral, PublicKeyToken=null
// Mafi.Core.Factory.Zippers.ZipperSetPriorityPortsCmd
using Mafi.Core;
using Mafi.Core.Input;
using Mafi.Serialization;
using System;


[GenerateSerializer(false, null, 0)]
public class blZipperSetPriorityPortsCmd : InputCommand
{
    public readonly EntityId ZipperId;

    public readonly char PortName;

    /// <summary>
    /// Acts like toggle if null.
    /// </summary>
    public readonly bool? IsPrioritized;

    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

    public blZipperSetPriorityPortsCmd(EntityId zipperId, char portName, bool? isPrioritized)
    {
        this.ZipperId = zipperId;
        this.PortName = portName;
        this.IsPrioritized = isPrioritized;
    }

    public static void Serialize(blZipperSetPriorityPortsCmd value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, blZipperSetPriorityPortsCmd.s_serializeDataDelayedAction);
        }
    }

    protected override void SerializeData(BlobWriter writer)
    {
        base.SerializeData(writer);
        writer.WriteNullableStruct(this.IsPrioritized);
        writer.WriteChar(this.PortName);
        EntityId.Serialize(this.ZipperId, writer);
    }

    public new static blZipperSetPriorityPortsCmd Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out blZipperSetPriorityPortsCmd obj, (Func<BlobReader, Type, blZipperSetPriorityPortsCmd>)null, (Func<BlobReader, string, blZipperSetPriorityPortsCmd>)null, nullObjIsOk: false))
        {
            reader.EnqueueDataDeserialization(obj, blZipperSetPriorityPortsCmd.s_deserializeDataDelayedAction);
        }
        return obj;
    }

    protected override void DeserializeData(BlobReader reader)
    {
        base.DeserializeData(reader);
        reader.SetField(this, "IsPrioritized", reader.ReadNullableStruct<bool>());
        reader.SetField(this, "PortName", reader.ReadChar());
        reader.SetField(this, "ZipperId", EntityId.Deserialize(reader));
    }

    static blZipperSetPriorityPortsCmd()
    {

        blZipperSetPriorityPortsCmd.s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((blZipperSetPriorityPortsCmd)obj).SerializeData(writer);
        };
        blZipperSetPriorityPortsCmd.s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((blZipperSetPriorityPortsCmd)obj).DeserializeData(reader);
        };
    }
}
