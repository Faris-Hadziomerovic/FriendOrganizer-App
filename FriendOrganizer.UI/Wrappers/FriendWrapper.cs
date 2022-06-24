using System;
using System.Collections.Generic;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Wrappers
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model) { }


        public int Id { get { return Model.Id; } }

        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }


        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            //ClearErrors(propertyName);

            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "", StringComparison.OrdinalIgnoreCase))
                        yield return "First name field is required!";

                    if (string.Equals(FirstName, "robot", StringComparison.OrdinalIgnoreCase))
                        yield return "No robots allowed!";

                    break;

                case nameof(LastName):
                    if (string.Equals(LastName, "robot", StringComparison.OrdinalIgnoreCase))
                        yield return "No robots allowed!";

                    break;

                default:
                    // Email != null because of the TargetNullValue='' property of the TextBox
                    if (Email != null && !Email.Contains("@") && Email.Length > 0)
                        yield return "For now at least put 1 instance of @ in this field!";
                    break;

            }
        }
    }
}
