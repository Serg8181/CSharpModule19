using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        FriendService friendService;

        public FriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            Console.WriteLine("Введите email друга:");
            var email = Console.ReadLine();

            try
            {

                friendService.AddFriend(email, user.Id);
                SuccessMessage.Show("Друг добавлен успешно!");

            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователя с таким email не существует!");
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("Введите корректный адрес.");
            }
            catch (Exception)
            {
                AlertMessage.Show("При добавлении друга, произошла ошибка!");
            }

        }
    }
}
