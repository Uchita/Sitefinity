using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using DataAnnotationsExtensions.ClientValidation;
using JXTPortal.Entities;

namespace JXTPortal.Domain.ViewModel
{
    public class MemberModel 
    {
        public class RegistrationModel
        {
            [StringLengthAttribute(50, MinimumLength = 5, ErrorMessage = "Username should have at least 5 characters")]
            [Required(ErrorMessage = "Username is required")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Password confirmation is required")]
            [EqualTo("Password", ErrorMessage = "'Password' and 'Confirm Password' do not match")]
            public string ConfirmPassword { get; set; }

            [Email(ErrorMessage = "The Email field is not a valid e-mail address")]
            [Required(ErrorMessage = "Email is required")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Confirm Email is required")]
            [EqualTo("Email", ErrorMessage = "'Email' and 'Confirm Email' do not match")]
            public string ConfirmEmail { get; set; }
        }

        public class ChangePasswordModel
        {
            [Required]
            public string OldPassword { get; set; }

            [Required]
            [EqualTo("ConfirmPassword")]
            public string NewPassword { get; set; }

            [Required]
            public string ConfirmPassword { get; set; }
        }

        public class ForgetPasswordModel
        {
            [Required(ErrorMessage = "Email Or Username is required")]
            public string UserNameEmail { get; set; }
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "Username is required")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public class MemberDetailModel
        { 
            //TODO: Member table, Job Alert?
        }

        public class MemberFilesModel
        {
            public MemberFilesModel()
            {
                Resumes = new List<MemberFiles>();
                CoverLetters = new List<MemberFiles>();
            }

            public List<MemberFiles> Resumes { get; set; }
            public List<MemberFiles> CoverLetters { get; set; }
        }

        public class ApplyJobModel
        {
            public ApplyJobModel()
            {
                MemberId = 0;
                FirstName = "";
                Surname = "";
                Email = "";
                ContactNo = "";
                ResumeID = 0;
                CoverLetterID = 0;
                Resumes = new List<MemberFiles>();
                CoverLetters = new List<MemberFiles>();
                IsValidJob = false;
                IsApplied = true;
                JobId = 0;
            }

            public int MemberId { get; set; }
            
            [Required(ErrorMessage="First Name is required")]
            public string FirstName {get;set;}

            [Required(ErrorMessage = "Surname is required")]
            public string Surname { get; set; }
            
            [Email]
            [Required(ErrorMessage = "Email is required")]
            public string Email {get;set;}

            [Required(ErrorMessage = "Contact No is required")]
            public string ContactNo {get;set;}
            
            public int ResumeID { get; set; }
            public int CoverLetterID { get; set; }
            public List<MemberFiles> Resumes { get; set; }
            public List<MemberFiles> CoverLetters { get; set; }
            public string Resume { get; set; }
            public string CoverLetter { get; set; }
            public int ResumeSelection { get; set; }
            public int CoverLetterSelection { get; set; }

            [Required(ErrorMessage = "Job Id is required")]
            public int JobId { get; set; }
            public bool IsValidJob { get; set; }
            public bool IsApplied { get; set; }
        }
    }
}
