﻿using System;
using Cake.Core.Diagnostics;
using Moq;
using Xunit;

namespace Cake.Path.UnitTests.GivenAnItem.ToAddToThePath
{
    public class WhenTheItemAlreadyExists
    {
        [Fact]
        public void ThenThePathIsNotModified()
        {
            var environmentWrapper = new Mock<IEnvironmentWrapper>();
            environmentWrapper.Setup(x => x.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine, string.Empty)).Returns("test;test2");

            var subject = new Path(new NullLog(), environmentWrapper.Object);
            subject.Add("test", new PathSettings { Target = PathTarget.Machine });

            environmentWrapper.Verify(x => x.SetEnvironmentVariable(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EnvironmentVariableTarget>()), Times.Never);
        }
    }
}