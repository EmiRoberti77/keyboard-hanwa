using System;
using System.Collections.Generic;
using System.Text;

namespace CommaBoard.License.Class
{
    public class CBLUser
    {

        public string id { get; set; }                          //  user id
        public string createdAt { get; set; }                   //  date user created
        public string updatedAt { get; set; }                   //  date user last updated
        public string name { get; set; }                        //  full name of user
        public string firstName { get; set; }                   //  first name of user
        public string lastName { get; set; }                    //  last name of user
        public string password { get; set; }                    //  user password
        public string company { get; set; }                     //  company
        public string email { get; set; }                       //  email
        public string role { get; set; }                        //  role for Cryptlex will be user
        public bool twoFactorEnabled { get; set; }              //  
        public bool googleSsoEnabled { get; set; }              //
        public bool allowCustomerPortalAccess { get; set; }     //
        public string lastLoginAt { get; set; }                 //  datetime last logged in
        public string lastSeenAt { get; set; }                  //  last seen at
        public Metadata[] metadata { get; set; }                //  any additional metadata fields

    }

    public class Metadata
    {

        public string id { get; set; }                          //  metadata id
        public string createdAt { get; set; }                   //  date metadata created
        public string updatedAt { get; set; }                   //  date metadata last updated
        public string key { get; set; }                         //  metadata key
        public string value { get; set; }                       //  metadata value
        public bool visible { get; set; }                       //  metadata visible
    }

    public class UserValidation
    {
        public string accountAlias { get; set; }                   //  Lex comapany Id - commandrooms
        public string email { get; set; }                    //  user's email
        public string password { get; set; }                    //  user's password


    }

    public class AccessToken
    {
        public string accessToken { get; set; }
    }

    public class ErrorMessage
    {
        public string message { get; set; }
        public string code { get; set; }
    }

    public class PersonalAccessToken
    {
        public string name { get; set; }
        public bool revoked { get; set; }
        public string expiresAt { get; set; }
        public string[] scopes { get; set; }

    }

    public class PasswordToken
    {
        public string resetPasswordToken { get; set; }
    }

    public class PasswordResetRequest
    {
        public string newPassword { get; set; }
        public string token { get; set; }
    }


}

