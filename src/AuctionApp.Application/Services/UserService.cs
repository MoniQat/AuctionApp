﻿using AuctionApp.Application.Interfaces;
using AuctionApp.Core.Entities;
using AuctionApp.Core.Resources;
using System.Text.RegularExpressions;

namespace AuctionApp.Application.Services
{
    public sealed class UserService() : IUserService
    {

        public async Task<UserInformationResource> GetInfo(User user)
        {
            var username = user.UserName;
            var firstName = user.FirstName;
            var lastName = user.LastName;
            var dateOfBirth = user.DateOfBirth;
            var profileImage = user.ProfileImage;
            var phoneNumber = Regex.Replace(user.PhoneNumber, @"(\d{2})(\d{3})(\d{3})(\d{2})(\d{2})", "$1($2)-$3-$4-$5");
            var email = user.Email;

            return new UserInformationResource(username, firstName, lastName, dateOfBirth, profileImage, phoneNumber, email);
        }
    }
}
