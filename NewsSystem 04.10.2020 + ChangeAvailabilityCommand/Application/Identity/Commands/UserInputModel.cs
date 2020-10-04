﻿namespace NewsSystem.Application.Identity.Commands
{
    public abstract class UserInputModel
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string Name { get; set; } = default!;
    }
}
