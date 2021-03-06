﻿using Shouldly;

using Xunit;

namespace ProGaudi.MsgPack.Light.Tests.Generators
{
    public class ClassTest : MapGeneratorTestBase
    {
        [Theory]
        [ClassData(typeof(FixtureProvider<MapFixture, ArrayFixture>))]
        public void WriteSmoke(ContextFixtureBase fixture)
        {
            var testObject = CreateTestObject();

            MsgPackSerializer.Serialize(testObject, fixture.NewContext).ShouldBe(MsgPackSerializer.Serialize(testObject, fixture.OldContext));
        }

        [Theory]
        [ClassData(typeof(FixtureProvider<MapFixture, ArrayFixture>))]
        public void ReadSmoke(ContextFixtureBase fixture)
        {
            var expected = CreateTestObject();

            var actual = MsgPackSerializer.Deserialize<ImageInfo>(MsgPackSerializer.Serialize(expected, fixture.NewContext), fixture.NewContext);
            AssertEqual(actual, expected);
        }

        [Theory]
        [ClassData(typeof(FixtureProvider<MapFixture, ArrayFixture>))]
        public void WriteNewReadOld(ContextFixtureBase fixture)
        {
            var expected = CreateTestObject();

            var actual = MsgPackSerializer.Deserialize<ImageInfo>(MsgPackSerializer.Serialize(expected, fixture.NewContext), fixture.OldContext);

            AssertEqual(actual, expected);
        }

        [Theory]
        [ClassData(typeof(FixtureProvider<MapFixture, ArrayFixture>))]
        public void WriteOldReadNew(ContextFixtureBase fixture)
        {
            var expected = CreateTestObject();

            var actual = MsgPackSerializer.Deserialize<ImageInfo>(MsgPackSerializer.Serialize(expected, fixture.OldContext), fixture.NewContext);
            AssertEqual(actual, expected);
        }
        
        public class MapFixture : MapContextFixture
        {
            public MapFixture()
            {
                NewContext.GenerateAndRegisterMapConverter<ImageInfo>();
            }
        }

        public class ArrayFixture : ArrayContextFixture
        {
            public ArrayFixture()
            {
                NewContext.GenerateAndRegisterArrayConverter<ImageInfo>();
            }
        }
    }
}
