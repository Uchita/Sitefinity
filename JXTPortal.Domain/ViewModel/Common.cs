using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Domain.ViewModel
{
    public class Common
    {
        public enum JXTMembershipStatus
        {
            Success = 0,
            InvalidUserName = 1,
            InvalidPassword = 2,
            InvalidQuestion = 3,
            InvalidAnswer = 4,
            InvalidEmail = 5,
            DuplicateUserName = 6,
            DuplicateEmail = 7,
            UserRejected = 8,
            InvalidProviderUserKey = 9,
            DuplicateProviderUserKey = 10,
            ProviderError = 11,
            InvalidPasswordOrUserName = 12,
            Inactivated = 13
        }

        public static string GetStatus(JXTMembershipStatus status)
        {
            if (status == JXTMembershipStatus.Success)
                return "Success";

            if (status == JXTMembershipStatus.InvalidUserName)
                return "Invalid username";

            if (status == JXTMembershipStatus.InvalidPassword)
                return "Invalid password";

            if (status == JXTMembershipStatus.InvalidQuestion)
                return "Invalid question";

            if (status == JXTMembershipStatus.InvalidAnswer)
                return "Invalid answer";

            if (status == JXTMembershipStatus.InvalidEmail)
                return "Invalid email";

            if (status == JXTMembershipStatus.DuplicateUserName)
                return "Duplicate username";

            if (status == JXTMembershipStatus.DuplicateEmail)
                return "Duplicate email";

            if (status == JXTMembershipStatus.UserRejected)
                return "User Rejected";
            if (status == JXTMembershipStatus.InvalidProviderUserKey)
                return "Invalid provider user key";

            if (status == JXTMembershipStatus.DuplicateProviderUserKey)
                return "Duplicate provider user key";

            if (status == JXTMembershipStatus.ProviderError)
                return "Provider error";

            if (status == JXTMembershipStatus.InvalidPasswordOrUserName)
                return "Invalid password or username";

            if (status == JXTMembershipStatus.Inactivated)
                return "Inactivated";

            return "Undefined";
        }
    }
}
