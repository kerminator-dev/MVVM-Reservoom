﻿using System.Threading.Tasks;

namespace Reservoom.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting = false;
        public bool IsExecuting
        {
            get => _isExecuting;
            private set
            {
                _isExecuting = value;
                OnCanExecutedChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }

        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
