using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using FriendOrganizer.UI.Events;

namespace FriendOrganizer.UI.Wrappers
{
    public class NotifyDataErrorInfoBase : Observable, INotifyDataErrorInfo
    {
        // INotifyDataErrorInfo implementation

        private Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
                return _errorsByPropertyName[propertyName];
            else
                return null;
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
                _errorsByPropertyName[propertyName] = new List<string>();

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                if (_errorsByPropertyName[propertyName].Any())
                {
                    _errorsByPropertyName[propertyName].Clear();
                    OnErrorsChanged(propertyName);
                }

                _errorsByPropertyName.Remove(propertyName);
            }
        }
    }
}
