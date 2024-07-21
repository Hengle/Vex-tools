﻿using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Vex.Library
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidResourceHeader
    {
        public int Magic;
        public short Version;
    }

    struct VoidContainer
    {
        public string Directory;
        public string Path;
        public List<string> Resources;
        public List<D2Entry> Entries;
        public VoidContainer()
        {
            Resources = [];
            Entries = [];
        }

        public readonly string ResourcePath(ushort flags)
        {
            string Result = string.Empty;

            int index = (flags & 0x8000) != 0 ? Resources.Count - 1 : (int)(flags >> 2);
            if (Resources.Count > index)
            {
                Result = Resources[index];
            }

            return Result;
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidMesh
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] Unk1;
        public uint Flags1;
        public uint Flags2;
        public Vector3 unkVec;
        public Vector3 unkVec2;
        public Vector2 unkVec3;
        public Vector2 unkVec4;
        public uint VertexCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Unk3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidMaterial
    {
        public int MeshId;
        public int VertexStart;
        public int VertexEnd;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidSkeleton
    {
        public uint FileSize;
        public uint unk0;
        public uint unk1a;
        public uint BoneCount;
        public uint unk1;
        public uint TransformOffset;
        public uint Data2Offset;
        public uint EndData1Offset;
        public uint EndData2Offset;
        public uint EndData3Offset;
        public uint Data2EndOffset;
        public uint MainDataOffset;
        public uint unk2;
        public uint unk3;
        public uint ExtJointCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] udata0;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidParents
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] test;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct VoidTransforms
    {
        public Vector4 Rotation;
        public Vector3 Position;
        public float unk1;
        public Vector3 Scale;
        public float unk2;
    }
}
