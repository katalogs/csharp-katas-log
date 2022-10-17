using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.User;

namespace TripServiceKata.Tests
{
    [TestClass]
    public class UserTests
    {

        [TestMethod]
        public void Should_return_true_when_users_are_friends()
        {
            var user1 = UserBuilder.AUser().Build();
            var user2 = UserBuilder.AUser().FriendWith(user1).Build();

            user2.IsFriend(user1).Should().BeTrue();
        }

        [TestMethod]
        public void Should_return_false_when_users_are_not_friends()
        {
            var user1 = UserBuilder.AUser();
            var user2 = UserBuilder.AUser().FriendWith(user1).Build();
            var user3 = UserBuilder.AUser().Build();

            user2.IsFriend(user3).Should().BeFalse();
        }
    }
}
