﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverTests
    {
        [Fact]
        public void RoverShouldMoveEverywhereOnMars()
        {
            var command = "FFLFRRFFRF";
            var rover = new Rover(2,2,'N');

            var result = rover.Move(command);

            Assert.Equal("3:3:S", result);
        }
    }
}