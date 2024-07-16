using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {       
        [Test]
        public void AddFriendMustThrowArgumentNullException()
        {   
            var service = new FriendService();
            Assert.Throws<ArgumentNullException>(()=>service.AddFriend("gf.com",1));
            Assert.Throws<ArgumentNullException>(() => service.AddFriend("", 1));
        }
    }
}