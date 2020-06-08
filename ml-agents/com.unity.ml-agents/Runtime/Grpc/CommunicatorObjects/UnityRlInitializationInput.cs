// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: mlagents_envs/communicator_objects/unity_rl_initialization_input.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MLAgents.CommunicatorObjects {

  /// <summary>Holder for reflection information generated from mlagents_envs/communicator_objects/unity_rl_initialization_input.proto</summary>
  internal static partial class UnityRlInitializationInputReflection {

    #region Descriptor
    /// <summary>File descriptor for mlagents_envs/communicator_objects/unity_rl_initialization_input.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UnityRlInitializationInputReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CkZtbGFnZW50c19lbnZzL2NvbW11bmljYXRvcl9vYmplY3RzL3VuaXR5X3Js",
            "X2luaXRpYWxpemF0aW9uX2lucHV0LnByb3RvEhRjb21tdW5pY2F0b3Jfb2Jq",
            "ZWN0cyJnCh9Vbml0eVJMSW5pdGlhbGl6YXRpb25JbnB1dFByb3RvEgwKBHNl",
            "ZWQYASABKAUSHQoVY29tbXVuaWNhdGlvbl92ZXJzaW9uGAIgASgJEhcKD3Bh",
            "Y2thZ2VfdmVyc2lvbhgDIAEoCUIfqgIcTUxBZ2VudHMuQ29tbXVuaWNhdG9y",
            "T2JqZWN0c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MLAgents.CommunicatorObjects.UnityRLInitializationInputProto), global::MLAgents.CommunicatorObjects.UnityRLInitializationInputProto.Parser, new[]{ "Seed", "CommunicationVersion", "PackageVersion" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// The initializaiton message - this is typically sent from the Python trainer to the C# environment.
  /// </summary>
  internal sealed partial class UnityRLInitializationInputProto : pb::IMessage<UnityRLInitializationInputProto> {
    private static readonly pb::MessageParser<UnityRLInitializationInputProto> _parser = new pb::MessageParser<UnityRLInitializationInputProto>(() => new UnityRLInitializationInputProto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<UnityRLInitializationInputProto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MLAgents.CommunicatorObjects.UnityRlInitializationInputReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityRLInitializationInputProto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityRLInitializationInputProto(UnityRLInitializationInputProto other) : this() {
      seed_ = other.seed_;
      communicationVersion_ = other.communicationVersion_;
      packageVersion_ = other.packageVersion_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public UnityRLInitializationInputProto Clone() {
      return new UnityRLInitializationInputProto(this);
    }

    /// <summary>Field number for the "seed" field.</summary>
    public const int SeedFieldNumber = 1;
    private int seed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Seed {
      get { return seed_; }
      set {
        seed_ = value;
      }
    }

    /// <summary>Field number for the "communication_version" field.</summary>
    public const int CommunicationVersionFieldNumber = 2;
    private string communicationVersion_ = "";
    /// <summary>
    /// Communication protocol version that the initiating side (typically the Python trainer) is using.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CommunicationVersion {
      get { return communicationVersion_; }
      set {
        communicationVersion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "package_version" field.</summary>
    public const int PackageVersionFieldNumber = 3;
    private string packageVersion_ = "";
    /// <summary>
    /// Package/library version that the initiating side (typically the Python trainer) is using.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PackageVersion {
      get { return packageVersion_; }
      set {
        packageVersion_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as UnityRLInitializationInputProto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(UnityRLInitializationInputProto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Seed != other.Seed) return false;
      if (CommunicationVersion != other.CommunicationVersion) return false;
      if (PackageVersion != other.PackageVersion) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Seed != 0) hash ^= Seed.GetHashCode();
      if (CommunicationVersion.Length != 0) hash ^= CommunicationVersion.GetHashCode();
      if (PackageVersion.Length != 0) hash ^= PackageVersion.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Seed != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Seed);
      }
      if (CommunicationVersion.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CommunicationVersion);
      }
      if (PackageVersion.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(PackageVersion);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Seed != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Seed);
      }
      if (CommunicationVersion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CommunicationVersion);
      }
      if (PackageVersion.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PackageVersion);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(UnityRLInitializationInputProto other) {
      if (other == null) {
        return;
      }
      if (other.Seed != 0) {
        Seed = other.Seed;
      }
      if (other.CommunicationVersion.Length != 0) {
        CommunicationVersion = other.CommunicationVersion;
      }
      if (other.PackageVersion.Length != 0) {
        PackageVersion = other.PackageVersion;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Seed = input.ReadInt32();
            break;
          }
          case 18: {
            CommunicationVersion = input.ReadString();
            break;
          }
          case 26: {
            PackageVersion = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
