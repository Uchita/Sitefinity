
using System;

namespace JXTPortal.EmailSender
{
    public class MockSender : IRichMessageEmailSender {
        
        public virtual void Send(String from, String to, String subject, String messageText) {

        }

        public virtual void Send(Message message, string bouncebackemail = "")
        {

        }

        public virtual void Send(Message[] messages) {

        }
    }
}