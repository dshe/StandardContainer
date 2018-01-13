﻿using System;
using Xunit;
using Xunit.Abstractions;
using MinimalContainer.Tests.Utility;

namespace MinimalContainer.Tests.Constructor
{
    public class ConstructorArgumentTests
    {
        protected readonly Action<string> Write;
        public ConstructorArgumentTests(ITestOutputHelper output) => Write = output.WriteLine;

        public class ClassWithValueTypeArgument
        {
            public ClassWithValueTypeArgument(int i) { }
        }
        [Fact]
        public void T01_Class_With_Value_Type_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            Assert.Throws<TypeAccessException>(() => container.Resolve<ClassWithValueTypeArgument>()).WriteMessageTo(Write);
        }

        public class ClassWithStringArgument
        {
            public ClassWithStringArgument(string s) { }
        }
        [Fact]
        public void T02_Class_With_String_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            Assert.Throws<TypeAccessException>(() => container.Resolve<ClassWithStringArgument>()).WriteMessageTo(Write);
        }

        public class ClassWithDefaultValueTypeArgument
        {
            public ClassWithDefaultValueTypeArgument(int i = 42) { }
        }
        [Fact]
        public void T03_Class_With_Default_Value_Type_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            container.Resolve<ClassWithDefaultValueTypeArgument>();
        }

        public class ClassWithDefaultStringArgument
        {
            public ClassWithDefaultStringArgument(string s = "test") { }
        }
        [Fact]
        public void T04_Class_With_Default_String_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            container.Resolve<ClassWithDefaultStringArgument>();
        }

        public class ClassWithNullArgument
        {
            public ClassWithNullArgument(string s = null) { }
        }
        [Fact]
        public void T05_Class_With_Null_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            container.Resolve<ClassWithNullArgument>();
        }

        public class ClassWithRefValueTypeArgument
        {
            public ClassWithRefValueTypeArgument(in int i = 7) { }
        }
        [Fact]
        public void T06_Class_With_Ref_Value_Type_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            container.Resolve<ClassWithRefValueTypeArgument>();
        }

        public class ClassWithRefRefTypeArgument
        {
            public ClassWithRefRefTypeArgument(in ClassX i) { }
        }
        [Fact]
        public void T07_Class_With_Ref_Ref_Type_Argument()
        {
            var container = new Container(DefaultLifestyle.Singleton, Write);
            container.Resolve<ClassWithRefRefTypeArgument>();
        }


    }

    public class ClassX
    {
        public ClassX() { }
    }

}
