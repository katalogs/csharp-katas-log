using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TripServiceKata.Tests
{

    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void should_return_false_when_users_are_not_friends()
        {
            User.User user1 = new User.User();
            User.User user2 = new User.User();
            
            Assert.IsFalse(user1.IsFriendWith(user2));
        }
        
        [TestMethod]
        public void should_return_true_when_users_are_not_friends()
        {
            User.User user1 = new User.User();
            User.User user2 = new User.User();
            
            user1.AddFriend(user2);
            
            Assert.IsTrue(user1.IsFriendWith(user2));
        }
    }
    
    
}
