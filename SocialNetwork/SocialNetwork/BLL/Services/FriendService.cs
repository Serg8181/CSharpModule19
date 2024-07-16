using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        FriendRepository friendRepository;
        UserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }
        
        public void AddFriend(string email, int user_Id)
        {

            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentNullException();

            var userEntity = userRepository.FindByEmail(email);
            if (userEntity == null)
            {
               throw new UserNotFoundException();
            }
            else
            {
                FriendEntity friendEntity = new FriendEntity()
                {
                    user_id = user_Id,
                    friend_id = userEntity.id
                };
               

                if(friendRepository.Create(friendEntity)== 0)
                    throw new Exception();
            }
        }
    } 
}
