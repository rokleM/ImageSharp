﻿// <copyright file="ColorConstructorTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests.Colors
{
    using System.Collections.Generic;
    using System.Numerics;
    using Xunit;

    public class ColorConstructorTests
    {
        public static IEnumerable<object[]> Vector4Data
        {
            get
            {
                var vector4Values = new Vector4[]
                    {
                        Vector4.Zero,
                        Vector4.One,
                        Vector4.UnitX,
                        Vector4.UnitY,
                        Vector4.UnitZ,
                        Vector4.UnitW,
                    };

                foreach (var vector4 in vector4Values)
                {
                    // using float array to work around a bug in xunit corruptint the state of any Vector4 passed as MemberData
                    var vector4Components = new float[] { vector4.X, vector4.Y, vector4.Z, vector4.W };

                    yield return new object[] { new Argb(vector4), vector4Components };
                    yield return new object[] { new Bgra4444(vector4), vector4Components };
                    yield return new object[] { new Bgra5551(vector4), vector4Components };
                    yield return new object[] { new Byte4(vector4), vector4Components };
                    yield return new object[] { new HalfVector4(vector4), vector4Components };
                    yield return new object[] { new NormalizedByte4(vector4), vector4Components };
                    yield return new object[] { new NormalizedShort4(vector4), vector4Components };
                    yield return new object[] { new Rgba1010102(vector4), vector4Components };
                    yield return new object[] { new Rgba64(vector4), vector4Components };
                    yield return new object[] { new Short4(vector4), vector4Components };
                }
            }
        }

        public static IEnumerable<object[]> Vector3Data
        {
            get
            {
                var vector3Values = new Dictionary<Vector3, Vector4>()
                    {
                        { Vector3.One, Vector4.One },
                        { Vector3.Zero, new Vector4(0, 0, 0, 1) },
                        { Vector3.UnitX, new Vector4(1, 0, 0, 1) },
                        { Vector3.UnitY, new Vector4(0, 1, 0, 1) },
                        { Vector3.UnitZ, new Vector4(0, 0, 1, 1) },
                    };

                foreach (var vector3 in vector3Values.Keys)
                {
                    var vector4 = vector3Values[vector3];
                    // using float array to work around a bug in xunit corruptint the state of any Vector4 passed as MemberData
                    var vector4Components = new float[] { vector4.X, vector4.Y, vector4.Z, vector4.W };

                    yield return new object[] { new Argb(vector3), vector4Components };
                    yield return new object[] { new Bgr565(vector3), vector4Components };
                }
            }
        }

        public static IEnumerable<object[]> Float4Data
        {
            get
            {
                var vector4Values = new Vector4[]
                    {
                        Vector4.Zero,
                        Vector4.One,
                        Vector4.UnitX,
                        Vector4.UnitY,
                        Vector4.UnitZ,
                        Vector4.UnitW,
                    };

                foreach (var vector4 in vector4Values)
                {
                    // using float array to work around a bug in xunit corruptint the state of any Vector4 passed as MemberData
                    var vector4Components = new float[] { vector4.X, vector4.Y, vector4.Z, vector4.W };

                    yield return new object[] { new Argb(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Bgra4444(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Bgra5551(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Byte4(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new HalfVector4(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new NormalizedByte4(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new NormalizedShort4(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Rgba1010102(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Rgba64(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                    yield return new object[] { new Short4(vector4.X, vector4.Y, vector4.Z, vector4.W), vector4Components };
                }
            }
        }

        public static IEnumerable<object[]> Float3Data
        {
            get
            {
                var vector3Values = new Dictionary<Vector3, Vector4>()
                    {
                        { Vector3.One, Vector4.One },
                        { Vector3.Zero, new Vector4(0, 0, 0, 1) },
                        { Vector3.UnitX, new Vector4(1, 0, 0, 1) },
                        { Vector3.UnitY, new Vector4(0, 1, 0, 1) },
                        { Vector3.UnitZ, new Vector4(0, 0, 1, 1) },
                    };

                foreach (var vector3 in vector3Values.Keys)
                {
                    var vector4 = vector3Values[vector3];
                    // using float array to work around a bug in xunit corruptint the state of any Vector4 passed as MemberData
                    var vector4Components = new float[] { vector4.X, vector4.Y, vector4.Z, vector4.W };

                    yield return new object[] { new Argb(vector3.X, vector3.Y, vector3.Z), vector4Components };
                    yield return new object[] { new Bgr565(vector3.X, vector3.Y, vector3.Z), vector4Components };
                }
            }
        }

        [Theory]
        [MemberData(nameof(Vector4Data))]
        [MemberData(nameof(Vector3Data))]
        [MemberData(nameof(Float4Data))]
        [MemberData(nameof(Float3Data))]
        public void ConstructorToVector4(IPixel packedVector, float[] expectedVector4Components)
        {
            // Arrange
            var precision = 2;
            // using float array to work around a bug in xunit corruptint the state of any Vector4 passed as MemberData
            var expectedVector4 = new Vector4(expectedVector4Components[0], expectedVector4Components[1], expectedVector4Components[2], expectedVector4Components[3]);

            // Act
            var vector4 = packedVector.ToVector4();

            // Assert
            Assert.Equal(expectedVector4.X, vector4.X, precision);
            Assert.Equal(expectedVector4.Y, vector4.Y, precision);
            Assert.Equal(expectedVector4.Z, vector4.Z, precision);
            Assert.Equal(expectedVector4.W, vector4.W, precision);
        }
    }
}
