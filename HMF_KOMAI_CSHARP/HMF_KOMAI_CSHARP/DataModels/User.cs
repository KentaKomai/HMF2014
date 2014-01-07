using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMF_KOMAI_CSHARP.DataModels
{
    public class User
    {
        private int id;
        public int Id
        {
            get { return id; }
            private set { this.id = value; }
        }

        private int age;
        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value;  }
        }

        private HandicapType handicap;
        public HandicapType Handicap
        {
            get { return this.handicap; }
            set { this.handicap = value; }
        }

        private AuthStatus status;
        public AuthStatus Status { 
            get { return status; }
            set { 
                this.status = value;
                if (this.status == AuthStatus.LOGINED)
                    LoginEvent(this);
                else if (this.status == AuthStatus.NO_LOGIN)
                    LogoutEvent(this);
            }
        }

        public event Action<Object> LoginEvent;
        public event Action<Object> LogoutEvent;

        public User() 
        {
            this.status = AuthStatus.NO_LOGIN;
        }

        public static void CheckAuthentication(byte[] fingerPrint, ref User user)
        {
            if (fingerPrint == null)
            {
                user.Id = int.MaxValue;
                user.FirstName = "FirstName";
                user.LastName = "LastName";
                user.Age = int.MaxValue;
                user.Handicap = HandicapType.NO_HANDICAP;
                user.Status = AuthStatus.LOGINED;
            }
        }

    }
}
